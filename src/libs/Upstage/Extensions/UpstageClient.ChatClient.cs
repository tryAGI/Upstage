#nullable enable

using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Meai = Microsoft.Extensions.AI;

namespace Upstage;

public partial class UpstageClient : Meai.IChatClient
{
    private Meai.ChatClientMetadata? _chatMetadata;

    /// <inheritdoc />
    object? Meai.IChatClient.GetService(Type? serviceType, object? serviceKey)
    {
        return
            serviceKey is not null ? null :
            serviceType == typeof(Meai.ChatClientMetadata) ? (_chatMetadata ??= new("upstage", BaseUri)) :
            serviceType?.IsInstanceOfType(this) is true ? this :
            null;
    }

    /// <inheritdoc />
    async Task<Meai.ChatResponse> Meai.IChatClient.GetResponseAsync(
        IEnumerable<Meai.ChatMessage> messages, Meai.ChatOptions? options, CancellationToken cancellationToken)
    {
        var request = CreateChatRequest(messages, options);

        var response = await Chat.CreateChatCompletionAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        Meai.ChatMessage responseMessage = new()
        {
            MessageId = response.Id,
            Role = Meai.ChatRole.Assistant,
            RawRepresentation = response,
        };

        if (response.Choices is { Count: > 0 })
        {
            var choice = response.Choices[0];
            var message = choice.Message;

            if (message?.Content is { Length: > 0 })
            {
                responseMessage.Contents.Add(new Meai.TextContent(message.Content) { RawRepresentation = message });
            }

            if (message?.ToolCalls is { Count: > 0 })
            {
                foreach (var toolCall in message.ToolCalls)
                {
                    IDictionary<string, object?>? arguments = null;
                    if (toolCall.Function.Arguments is { Length: > 0 })
                    {
                        arguments = JsonSerializer.Deserialize<Dictionary<string, object?>>(
                            toolCall.Function.Arguments,
                            JsonSerializerContext.Options);
                    }

                    responseMessage.Contents.Add(new Meai.FunctionCallContent(
                        toolCall.Id,
                        toolCall.Function.Name,
                        arguments)
                    {
                        RawRepresentation = toolCall,
                    });
                }
            }
        }

        Meai.ChatResponse completion = new(responseMessage)
        {
            RawRepresentation = response,
            ResponseId = response.Id,
            ModelId = response.Model,
            FinishReason = response.Choices is { Count: > 0 }
                ? response.Choices[0].FinishReason switch
                {
                    ChatCompletionChoiceFinishReason.Stop => Meai.ChatFinishReason.Stop,
                    ChatCompletionChoiceFinishReason.Length => Meai.ChatFinishReason.Length,
                    ChatCompletionChoiceFinishReason.ToolCalls => Meai.ChatFinishReason.ToolCalls,
                    ChatCompletionChoiceFinishReason.ContentFilter => Meai.ChatFinishReason.ContentFilter,
                    _ => null,
                }
                : null,
        };

        if (response.Usage is { } u)
        {
            completion.Usage = new()
            {
                InputTokenCount = u.PromptTokens,
                OutputTokenCount = u.CompletionTokens,
                TotalTokenCount = u.TotalTokens,
            };
        }

        return completion;
    }

    /// <inheritdoc />
    async IAsyncEnumerable<Meai.ChatResponseUpdate> Meai.IChatClient.GetStreamingResponseAsync(
        IEnumerable<Meai.ChatMessage> messages, Meai.ChatOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var request = CreateChatRequest(messages, options);
        request.Stream = true;

        // Build the HTTP request manually for SSE streaming
        var requestBody = request.ToJson(JsonSerializerContext);

        using var httpRequest = new HttpRequestMessage(HttpMethod.Post, new Uri("chat/completions", UriKind.Relative));
        httpRequest.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        foreach (var authorization in Authorizations)
        {
            if (authorization.Type is "Http" or "OAuth2")
            {
                httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    scheme: authorization.Name,
                    parameter: authorization.Value);
            }
            else if (authorization.Type == "ApiKey" && authorization.Location == "Header")
            {
                httpRequest.Headers.Add(authorization.Name, authorization.Value);
            }
        }

        using var httpResponse = await HttpClient.SendAsync(
            httpRequest,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken).ConfigureAwait(false);
        httpResponse.EnsureSuccessStatusCode();

        using var stream = await httpResponse.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        using var reader = new StreamReader(stream);

        // Accumulate tool call chunks by index so we can emit complete arguments
        var toolCallBuilders = new Dictionary<int, (string Id, string Name, StringBuilder Args)>();

        string? line;
        while ((line = await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false)) is not null)
        {
            if (!line.StartsWith("data: ", StringComparison.Ordinal))
                continue;

            var data = line["data: ".Length..];
            if (data == "[DONE]")
                break;

            ChatCompletionChunkResponse? chunk;
            try
            {
                chunk = ChatCompletionChunkResponse.FromJson(data, JsonSerializerContext);
            }
            catch (JsonException)
            {
                continue;
            }

            if (chunk is null)
                continue;

            if (chunk.Choices is not { Count: > 0 })
            {
                // Usage-only chunk
                if (chunk.Usage is { } usageOnly)
                {
                    yield return new Meai.ChatResponseUpdate
                    {
                        ModelId = chunk.Model,
                        Contents = [new Meai.UsageContent(new()
                        {
                            InputTokenCount = usageOnly.PromptTokens,
                            OutputTokenCount = usageOnly.CompletionTokens,
                            TotalTokenCount = usageOnly.TotalTokens,
                        })],
                    };
                }
                continue;
            }

            foreach (var choice in chunk.Choices)
            {
                var delta = choice.Delta;

                Meai.ChatResponseUpdate update = new()
                {
                    ResponseId = chunk.Id,
                    ModelId = chunk.Model,
                    RawRepresentation = chunk,
                    Role = Meai.ChatRole.Assistant,
                };

                if (delta?.Content is { Length: > 0 })
                {
                    update.Contents.Add(new Meai.TextContent(delta.Content) { RawRepresentation = delta });
                }

                // Tool call chunks -- accumulate arguments by index
                if (delta?.ToolCalls is { Count: > 0 })
                {
                    foreach (var tc in delta.ToolCalls)
                    {
                        var index = tc.Index ?? 0;
                        if (!toolCallBuilders.TryGetValue(index, out var builder))
                        {
                            builder = (
                                Id: tc.Id ?? string.Empty,
                                Name: tc.Function?.Name ?? string.Empty,
                                Args: new StringBuilder());
                            toolCallBuilders[index] = builder;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tc.Id))
                                toolCallBuilders[index] = builder with { Id = tc.Id! };
                            if (!string.IsNullOrEmpty(tc.Function?.Name))
                                toolCallBuilders[index] = builder with { Name = tc.Function!.Name };
                        }

                        if (!string.IsNullOrEmpty(tc.Function?.Arguments))
                        {
                            toolCallBuilders[index].Args.Append(tc.Function!.Arguments);
                        }
                    }
                }

                // Finish reason -- emit accumulated tool calls when finished
                if (choice.FinishReason is { } finishReason)
                {
                    update.FinishReason = finishReason switch
                    {
                        ChatCompletionChunkChoiceFinishReason.Stop => Meai.ChatFinishReason.Stop,
                        ChatCompletionChunkChoiceFinishReason.Length => Meai.ChatFinishReason.Length,
                        ChatCompletionChunkChoiceFinishReason.ToolCalls => Meai.ChatFinishReason.ToolCalls,
                        ChatCompletionChunkChoiceFinishReason.ContentFilter => Meai.ChatFinishReason.ContentFilter,
                        _ => null,
                    };

                    // Emit complete tool calls with fully accumulated arguments
                    foreach (var (_, tcBuilder) in toolCallBuilders)
                    {
                        IDictionary<string, object?>? arguments = null;
                        var argsJson = tcBuilder.Args.ToString();
                        if (argsJson.Length > 0)
                        {
                            try
                            {
                                arguments = JsonSerializer.Deserialize<Dictionary<string, object?>>(
                                    argsJson, JsonSerializerContext.Options);
                            }
                            catch (JsonException)
                            {
                                // Ignore malformed JSON
                            }
                        }

                        update.Contents.Add(new Meai.FunctionCallContent(
                            tcBuilder.Id, tcBuilder.Name, arguments));
                    }

                    toolCallBuilders.Clear();
                }

                if (chunk.Usage is { } u)
                {
                    update.Contents.Add(new Meai.UsageContent(new()
                    {
                        InputTokenCount = u.PromptTokens,
                        OutputTokenCount = u.CompletionTokens,
                        TotalTokenCount = u.TotalTokens,
                    }));
                }

                yield return update;
            }
        }
    }

    private ChatCompletionRequest CreateChatRequest(IEnumerable<Meai.ChatMessage> chatMessages, Meai.ChatOptions? options)
    {
        var upstageMessages = new List<ChatMessage>();

        foreach (var chatMessage in chatMessages)
        {
            var role = chatMessage.Role == Meai.ChatRole.System ? ChatMessageRole.System :
                       chatMessage.Role == Meai.ChatRole.Assistant ? ChatMessageRole.Assistant :
                       chatMessage.Role == Meai.ChatRole.Tool ? ChatMessageRole.Tool :
                       ChatMessageRole.User;

            var upstageMessage = new ChatMessage
            {
                Role = role,
                Content = string.Empty,
            };

            var contentParts = new List<ChatContentPart>();
            string? simpleText = null;
            var hasMultipleParts = false;

            foreach (var content in chatMessage.Contents)
            {
                switch (content)
                {
                    case Meai.TextContent tc:
                        if (!hasMultipleParts && simpleText is null && contentParts.Count == 0)
                        {
                            simpleText = tc.Text ?? string.Empty;
                        }
                        else
                        {
                            if (!hasMultipleParts && simpleText is not null)
                            {
                                // Move existing text to parts
                                contentParts.Add(new ChatContentPart
                                {
                                    Type = ChatContentPartType.Text,
                                    Text = simpleText,
                                });
                                simpleText = null;
                                hasMultipleParts = true;
                            }
                            contentParts.Add(new ChatContentPart
                            {
                                Type = ChatContentPartType.Text,
                                Text = tc.Text ?? string.Empty,
                            });
                        }
                        break;

                    case Meai.DataContent dc when dc.HasTopLevelMediaType("image"):
                        hasMultipleParts = true;
                        if (simpleText is not null)
                        {
                            contentParts.Add(new ChatContentPart
                            {
                                Type = ChatContentPartType.Text,
                                Text = simpleText,
                            });
                            simpleText = null;
                        }

                        contentParts.Add(new ChatContentPart
                        {
                            Type = ChatContentPartType.ImageUrl,
                            ImageUrl = new ChatContentPartImageUrl
                            {
                                Url = dc.Uri,
                            },
                        });
                        break;

                    case Meai.UriContent uc when uc.HasTopLevelMediaType("image"):
                        hasMultipleParts = true;
                        if (simpleText is not null)
                        {
                            contentParts.Add(new ChatContentPart
                            {
                                Type = ChatContentPartType.Text,
                                Text = simpleText,
                            });
                            simpleText = null;
                        }

                        contentParts.Add(new ChatContentPart
                        {
                            Type = ChatContentPartType.ImageUrl,
                            ImageUrl = new ChatContentPartImageUrl
                            {
                                Url = uc.Uri.ToString(),
                            },
                        });
                        break;

                    case Meai.FunctionCallContent fcc:
                        upstageMessage.Role = ChatMessageRole.Assistant;
                        upstageMessage.ToolCalls ??= [];
                        upstageMessage.ToolCalls.Add(new ToolCall
                        {
                            Id = fcc.CallId,
                            Function = new ToolCallFunction
                            {
                                Name = fcc.Name,
                                Arguments = JsonSerializer.Serialize(
                                    fcc.Arguments,
                                    JsonSerializerContext.Options),
                            },
                        });
                        break;

                    case Meai.FunctionResultContent frc:
                        upstageMessage.Role = ChatMessageRole.Tool;
                        upstageMessage.ToolCallId = frc.CallId;
                        simpleText = frc.Result?.ToString() ?? string.Empty;
                        break;
                }
            }

            if (hasMultipleParts || contentParts.Count > 0)
            {
                upstageMessage.Content = new OneOf<string, IList<ChatContentPart>>(contentParts);
            }
            else
            {
                upstageMessage.Content = simpleText ?? string.Empty;
            }

            upstageMessages.Add(upstageMessage);
        }

        var request = options?.RawRepresentationFactory?.Invoke(this) as ChatCompletionRequest;
        if (request is not null)
        {
            request.Model = options?.ModelId ?? "solar-pro";
            if (request.Messages is null)
            {
                request.Messages = upstageMessages;
            }
            else
            {
                foreach (var message in upstageMessages)
                {
                    request.Messages.Add(message);
                }
            }
        }
        else
        {
            request = new ChatCompletionRequest
            {
                Model = options?.ModelId ?? "solar-pro",
                Messages = upstageMessages,
            };
        }

        request.MaxTokens ??= options?.MaxOutputTokens;
        request.Temperature ??= options?.Temperature;
        request.TopP ??= options?.TopP;
        request.Seed ??= (int?)options?.Seed;

        if (options?.StopSequences is { Count: > 0 } stops)
        {
            request.Stop ??= new OneOf<string, IList<string>>(stops.ToList());
        }

        if (options?.FrequencyPenalty is { } freqPenalty)
        {
            request.FrequencyPenalty ??= freqPenalty;
        }

        if (options?.PresencePenalty is { } presPenalty)
        {
            request.PresencePenalty ??= presPenalty;
        }

        if (options?.Tools is { Count: > 0 } aiTools)
        {
            var tools = request.Tools ?? [];
            request.Tools = tools;

            foreach (var tool in aiTools)
            {
                if (tool is Meai.AIFunction f)
                {
                    tools.Add(new ChatCompletionTool
                    {
                        Type = ChatCompletionToolType.Function,
                        Function = new FunctionDefinition
                        {
                            Name = f.Name,
                            Description = f.Description,
                            Parameters = f.JsonSchema,
                        },
                    });
                }
            }
        }

        if (options?.Tools is { Count: > 0 })
        {
            if (request.ToolChoice is null || request.ToolChoice.Value.Object is null)
            {
                if (options.ToolMode is Meai.AutoChatToolMode)
                {
                    request.ToolChoice = new OneOf<ChatCompletionRequestToolChoice?, ChatCompletionNamedToolChoice>(
                        ChatCompletionRequestToolChoice.Auto);
                }
                else if (options.ToolMode is Meai.RequiredChatToolMode r)
                {
                    if (r.RequiredFunctionName is not null)
                    {
                        request.ToolChoice = new OneOf<ChatCompletionRequestToolChoice?, ChatCompletionNamedToolChoice>(
                            new ChatCompletionNamedToolChoice
                            {
                                Type = ChatCompletionNamedToolChoiceType.Function,
                                Function = new ChatCompletionNamedToolChoiceFunction
                                {
                                    Name = r.RequiredFunctionName,
                                },
                            });
                    }
                    else
                    {
                        request.ToolChoice = new OneOf<ChatCompletionRequestToolChoice?, ChatCompletionNamedToolChoice>(
                            ChatCompletionRequestToolChoice.Required);
                    }
                }
            }
        }

        return request;
    }
}
