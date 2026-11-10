
#nullable enable

namespace Upstage
{
    public partial class ChatClient
    {


        private static readonly global::Upstage.EndPointSecurityRequirement s_CreateChatCompletionAsStreamSecurityRequirement0 =
            new global::Upstage.EndPointSecurityRequirement
            {
                Authorizations = new global::Upstage.EndPointAuthorizationRequirement[]
                {                    new global::Upstage.EndPointAuthorizationRequirement
                    {
                        Type = "Http",
                        SchemeId = "BearerAuth",
                        Location = "Header",
                        Name = "Bearer",
                        FriendlyName = "Bearer",
                    },
                },
            };
        private static readonly global::Upstage.EndPointSecurityRequirement[] s_CreateChatCompletionAsStreamSecurityRequirements =
            new global::Upstage.EndPointSecurityRequirement[]
            {                s_CreateChatCompletionAsStreamSecurityRequirement0,
            };
        partial void PrepareCreateChatCompletionAsStreamArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Upstage.ChatCompletionRequest request);
        partial void PrepareCreateChatCompletionAsStreamRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Upstage.ChatCompletionRequest request);
        partial void ProcessCreateChatCompletionAsStreamResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// Create chat completion<br/>
        /// Creates a model response for the given chat conversation.<br/>
        /// Supports Solar Pro, Solar Mini, and Solar Mini JA models.<br/>
        /// Compatible with OpenAI chat completions API format.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Upstage.ApiException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Upstage.ChatCompletionChunkResponse> CreateChatCompletionAsStreamAsync(

            global::Upstage.ChatCompletionRequest request,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            request = new global::Upstage.ChatCompletionRequest
            {
                Model = request.Model,
                Messages = request.Messages,
                Temperature = request.Temperature,
                TopP = request.TopP,
                MaxTokens = request.MaxTokens,
                Stop = request.Stop,
                Stream = true,
                N = request.N,
                Seed = request.Seed,
                FrequencyPenalty = request.FrequencyPenalty,
                PresencePenalty = request.PresencePenalty,
                ResponseFormat = request.ResponseFormat,
                Tools = request.Tools,
                ToolChoice = request.ToolChoice,
            };
            PrepareArguments(
                client: HttpClient);
            PrepareCreateChatCompletionAsStreamArguments(
                httpClient: HttpClient,
                request: request);


            var __authorizations = global::Upstage.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_CreateChatCompletionAsStreamSecurityRequirements,
                operationName: "CreateChatCompletionAsStreamAsync");

            using var __timeoutCancellationTokenSource = global::Upstage.AutoSDKRequestOptionsSupport.CreateTimeoutCancellationTokenSource(
                clientOptions: Options,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);
            var __effectiveCancellationToken = __timeoutCancellationTokenSource?.Token ?? cancellationToken;
            var __effectiveReadResponseAsString = global::Upstage.AutoSDKRequestOptionsSupport.GetReadResponseAsString(
                clientOptions: Options,
                requestOptions: requestOptions,
                fallbackValue: ReadResponseAsString);
            var __maxAttempts = global::Upstage.AutoSDKRequestOptionsSupport.GetMaxAttempts(
                clientOptions: Options,
                requestOptions: requestOptions,
                supportsRetry: false);

            global::System.Net.Http.HttpRequestMessage __CreateHttpRequest()
            {

                            var __pathBuilder = new global::Upstage.PathBuilder(
                                path: "/chat/completions",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::Upstage.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Post,
                    requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
                __httpRequest.Version = global::System.Net.HttpVersion.Version11;
                __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

                __httpRequest.Headers.TryAddWithoutValidation(
                    "Accept",
                    "text/event-stream");

            foreach (var __authorization in __authorizations)
            {
                if (__authorization.Type == "Http" ||
                    __authorization.Type == "OAuth2" ||
                    __authorization.Type == "OpenIdConnect")
                {
                    __httpRequest.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: __authorization.Name,
                        parameter: __authorization.Value);
                }
                else if (__authorization.Type == "ApiKey" &&
                         __authorization.Location == "Header")
                {
                    __httpRequest.Headers.Add(__authorization.Name, __authorization.Value);
                }
            }
                            var __httpRequestContentBody = request.ToJson(JsonSerializerContext);
                            var __httpRequestContent = new global::System.Net.Http.StringContent(
                                content: __httpRequestContentBody,
                                encoding: global::System.Text.Encoding.UTF8,
                                mediaType: "application/json");
                            __httpRequest.Content = __httpRequestContent;
                global::Upstage.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PrepareCreateChatCompletionAsStreamRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    request: request);

                return __httpRequest;
            }

            global::System.Net.Http.HttpRequestMessage? __httpRequest = null;
            global::System.Net.Http.HttpResponseMessage? __response = null;
            var __attemptNumber = 0;
            try
            {
                for (var __attempt = 1; __attempt <= __maxAttempts; __attempt++)
                {
                    __attemptNumber = __attempt;
                    __httpRequest = __CreateHttpRequest();
                    await global::Upstage.AutoSDKRequestOptionsSupport.OnBeforeRequestAsync(
                            clientOptions: Options,
                            context: global::Upstage.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateChatCompletionAsStream",
                                methodName: "CreateChatCompletionAsStreamAsync",
                                pathTemplate: "\"/chat/completions\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest ?? throw new global::System.InvalidOperationException("The HTTP request was not created before invoking a request hook."),
                                response: null,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                    try
                    {
                        __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
                cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                    }
                    catch (global::System.Net.Http.HttpRequestException __exception)
                    {
                        var __retryDelay = global::Upstage.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: null,
                            attempt: __attempt);
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::Upstage.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Upstage.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateChatCompletionAsStream",
                                methodName: "CreateChatCompletionAsStreamAsync",
                                pathTemplate: "\"/chat/completions\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest ?? throw new global::System.InvalidOperationException("The HTTP request was not created before invoking a request hook."),
                                response: null,
                                exception: __exception,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: __willRetry,
                                retryDelay: __willRetry ? __retryDelay : (global::System.TimeSpan?)null,
                                retryReason: "exception",
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Upstage.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::Upstage.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        var __retryDelay = global::Upstage.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: __response,
                            attempt: __attempt);
                        await global::Upstage.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Upstage.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateChatCompletionAsStream",
                                methodName: "CreateChatCompletionAsStreamAsync",
                                pathTemplate: "\"/chat/completions\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest ?? throw new global::System.InvalidOperationException("The HTTP request was not created before invoking a request hook."),
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: true,
                                retryDelay: __retryDelay,
                                retryReason: "status:" + ((int)__response.StatusCode).ToString(global::System.Globalization.CultureInfo.InvariantCulture),
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Upstage.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    break;
                }

                if (__response == null)
                {
                    throw new global::System.InvalidOperationException("No response received.");
                }

                using (__response)
                {

                ProcessResponse(
                    client: HttpClient,
                    response: __response);
                ProcessCreateChatCompletionAsStreamResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Upstage.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Upstage.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateChatCompletionAsStream",
                                methodName: "CreateChatCompletionAsStreamAsync",
                                pathTemplate: "\"/chat/completions\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest ?? throw new global::System.InvalidOperationException("The HTTP request was not created before invoking a request hook."),
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::Upstage.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Upstage.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateChatCompletionAsStream",
                                methodName: "CreateChatCompletionAsStreamAsync",
                                pathTemplate: "\"/chat/completions\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest ?? throw new global::System.InvalidOperationException("The HTTP request was not created before invoking a request hook."),
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }

                            try
                            {
                                __response.EnsureSuccessStatusCode();
                            }
                            catch (global::System.Net.Http.HttpRequestException __ex)
                            {
                                string? __content = null;
                                try
                                {
                                    __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                        __effectiveCancellationToken
                #endif
                                    ).ConfigureAwait(false);
                                }
                                catch (global::System.Exception)
                                {
                                }

                                throw global::Upstage.ApiException.Create(
                                    statusCode: __response.StatusCode,
                                    message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                    innerException: __ex,
                                    responseBody: __content,
                                    responseHeaders: global::System.Linq.Enumerable.ToDictionary(
                                        __response.Headers,
                                        h => h.Key,
                                        h => h.Value));
                            }

                            using var __stream = await __response.Content.ReadAsStreamAsync(
                #if NET5_0_OR_GREATER
                                __effectiveCancellationToken
                #endif
                            ).ConfigureAwait(false);

                            await foreach (var __sseEvent in global::System.Net.ServerSentEvents.SseParser
                                .Create(__stream).EnumerateAsync(__effectiveCancellationToken))
                            {
                                var __content = __sseEvent.Data;
                                if (__content == "[DONE]")
                                {
                                    yield break;
                                }

                                var __streamedResponse = global::Upstage.ChatCompletionChunkResponse.FromJson(__content, JsonSerializerContext) ??
                                                       throw global::Upstage.ApiException.Create(
                                                           statusCode: __response.StatusCode,
                                                           message: $"Response deserialization failed for \"{__content}\" ",
                                                           innerException: null,
                                                           responseBody: __content,
                                                           responseHeaders: global::System.Linq.Enumerable.ToDictionary(
                                                               __response.Headers,
                                                               h => h.Key,
                                                               h => h.Value));

                                yield return __streamedResponse;
                            }

                }
            }
            finally
            {
                __httpRequest?.Dispose();
            }
        }
        /// <summary>
        /// Create chat completion<br/>
        /// Creates a model response for the given chat conversation.<br/>
        /// Supports Solar Pro, Solar Mini, and Solar Mini JA models.<br/>
        /// Compatible with OpenAI chat completions API format.
        /// </summary>
        /// <param name="model">
        /// The model to use for chat completion.<br/>
        /// Available models: solar-pro, solar-mini, solar-mini-ja<br/>
        /// Example: solar-pro
        /// </param>
        /// <param name="messages">
        /// A list of messages comprising the conversation so far.
        /// </param>
        /// <param name="temperature">
        /// Sampling temperature between 0 and 2. Higher values make output more random.<br/>
        /// Default Value: 1.0
        /// </param>
        /// <param name="topP">
        /// Nucleus sampling parameter. Only tokens with top_p probability mass are considered.<br/>
        /// Default Value: 1.0
        /// </param>
        /// <param name="maxTokens">
        /// Maximum number of tokens to generate in the response.
        /// </param>
        /// <param name="stop">
        /// Up to 4 sequences where the API will stop generating further tokens.
        /// </param>
        /// <param name="n">
        /// How many chat completion choices to generate for each input message.<br/>
        /// Default Value: 1
        /// </param>
        /// <param name="seed">
        /// If specified, the system will make a best effort to sample deterministically.
        /// </param>
        /// <param name="frequencyPenalty">
        /// Penalizes new tokens based on their existing frequency in the text so far.<br/>
        /// Default Value: 0
        /// </param>
        /// <param name="presencePenalty">
        /// Penalizes new tokens based on whether they appear in the text so far.<br/>
        /// Default Value: 0
        /// </param>
        /// <param name="responseFormat"></param>
        /// <param name="tools">
        /// A list of tools the model may call.
        /// </param>
        /// <param name="toolChoice">
        /// Controls which (if any) tool is called by the model.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Collections.Generic.IAsyncEnumerable<global::Upstage.ChatCompletionChunkResponse> CreateChatCompletionAsStreamAsync(
            string model,
            global::System.Collections.Generic.IList<global::Upstage.ChatMessage> messages,
            double? temperature = default,
            double? topP = default,
            int? maxTokens = default,
            global::Upstage.OneOf<string, global::System.Collections.Generic.IList<string>>? stop = default,
            int? n = default,
            int? seed = default,
            double? frequencyPenalty = default,
            double? presencePenalty = default,
            global::Upstage.ResponseFormat? responseFormat = default,
            global::System.Collections.Generic.IList<global::Upstage.ChatCompletionTool>? tools = default,
            global::Upstage.OneOf<global::Upstage.ChatCompletionRequestToolChoice?, global::Upstage.ChatCompletionNamedToolChoice>? toolChoice = default,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Upstage.ChatCompletionRequest
            {
                Model = model,
                Messages = messages,
                Temperature = temperature,
                TopP = topP,
                MaxTokens = maxTokens,
                Stop = stop,
                Stream = true,
                N = n,
                Seed = seed,
                FrequencyPenalty = frequencyPenalty,
                PresencePenalty = presencePenalty,
                ResponseFormat = responseFormat,
                Tools = tools,
                ToolChoice = toolChoice,
            };

            var __enumerable = CreateChatCompletionAsStreamAsync(
                request: __request,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);

            await foreach (var __response in __enumerable)
            {
                yield return __response;
            }
        }
    }
}