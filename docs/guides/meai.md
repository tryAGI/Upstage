# Microsoft.Extensions.AI Integration

!!! tip "Cross-SDK comparison"
    See the [centralized MEAI documentation](https://tryagi.github.io/docs/meai/) for feature matrices and comparisons across all tryAGI SDKs.

The Upstage SDK implements `IChatClient` and `IEmbeddingGenerator<string, Embedding<float>>` and provides `AIFunction` tool wrappers, all compatible with [Microsoft.Extensions.AI](https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai).

## Installation

```bash
dotnet add package Upstage
```

## Namespace Note

The Upstage SDK has its own `IChatClient` and `ChatMessage` types that conflict with `Microsoft.Extensions.AI`. Use the `Meai` alias:

```csharp
using Meai = Microsoft.Extensions.AI;
```

## Chat Completions

`UpstageClient` implements `IChatClient`, so you can use it with the standard MEAI interface.

```csharp
using Upstage;
using Meai = Microsoft.Extensions.AI;

Meai.IChatClient client = new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

var response = await client.GetResponseAsync(
    "What is the capital of France?",
    new Meai.ChatOptions { ModelId = "solar-pro" });

Console.WriteLine(response.Text);
```

## Streaming

```csharp
using Upstage;
using Meai = Microsoft.Extensions.AI;

Meai.IChatClient client = new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

await foreach (var update in client.GetStreamingResponseAsync(
    "Explain quantum computing in simple terms.",
    new Meai.ChatOptions { ModelId = "solar-pro" }))
{
    Console.Write(update.Text);
}
```

## Tool Calling

```csharp
using Upstage;
using Meai = Microsoft.Extensions.AI;

Meai.IChatClient client = new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

var tool = Meai.AIFunctionFactory.Create(
    (string location) => $"The weather in {location} is sunny, 22C.",
    "GetWeather",
    "Gets the current weather for a given location.");

var options = new Meai.ChatOptions
{
    ModelId = "solar-pro",
    Tools = [tool],
};

var messages = new List<Meai.ChatMessage>
{
    new(Meai.ChatRole.User, "What is the weather in Seoul?"),
};

while (true)
{
    var response = await client.GetResponseAsync(messages, options);
    messages.AddRange(response.ToChatMessages());

    if (response.FinishReason == Meai.ChatFinishReason.ToolCalls)
    {
        var results = await response.CallToolsAsync(options);
        messages.AddRange(results);
        continue;
    }

    Console.WriteLine(response.Text);
    break;
}
```

## Embeddings

`UpstageClient` implements `IEmbeddingGenerator<string, Embedding<float>>` for text embeddings.

```csharp
using Upstage;
using Meai = Microsoft.Extensions.AI;

Meai.IEmbeddingGenerator<string, Meai.Embedding<float>> generator =
    new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

var embeddings = await generator.GenerateAsync(
    ["Hello, world!", "How are you?"],
    new Meai.EmbeddingGenerationOptions { ModelId = "embedding-query" });

Console.WriteLine($"Generated {embeddings.Count} embeddings");
Console.WriteLine($"Dimensions: {embeddings[0].Vector.Length}");

if (embeddings.Usage is { } usage)
{
    Console.WriteLine($"Input tokens: {usage.InputTokenCount}");
    Console.WriteLine($"Total tokens: {usage.TotalTokenCount}");
}
```

## AIFunction Tools

The SDK provides `AIFunction` tool wrappers for Upstage's unique capabilities, usable with any `IChatClient`:

### Groundedness Check

Verify whether an answer is factually supported by a given context.

```csharp
using Upstage;
using Meai = Microsoft.Extensions.AI;

var upstage = new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

var groundednessTool = upstage.AsGroundednessCheckTool();

// Use with any IChatClient
Meai.IChatClient chatClient = /* any IChatClient */;

var options = new Meai.ChatOptions
{
    Tools = [groundednessTool],
};
```

### Translation

Translate text between languages using Solar translation models.

```csharp
using Upstage;

var upstage = new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

var translateTool = upstage.AsTranslateTool();

// Supports English-Korean and other language pairs
```

### Document Parse

Parse documents (PDFs, images) and extract structured content.

```csharp
using Upstage;

var upstage = new UpstageClient(apiKey: Environment.GetEnvironmentVariable("UPSTAGE_API_KEY")!);

var parseTool = upstage.AsDocumentParseTool(outputFormats: "html,markdown,text");

// Accepts base64-encoded document content
```

## Dependency Injection

```csharp
using Upstage;
using Meai = Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Meai.IChatClient>(
    new UpstageClient(apiKey: builder.Configuration["Upstage:ApiKey"]!));

builder.Services.AddSingleton<Meai.IEmbeddingGenerator<string, Meai.Embedding<float>>>(
    new UpstageClient(apiKey: builder.Configuration["Upstage:ApiKey"]!));
```

## Provider Metadata

```csharp
var chatMetadata = Meai.ChatClientExtensions.GetService<Meai.ChatClientMetadata>(client);
Console.WriteLine($"Provider: {chatMetadata?.ProviderName}"); // "upstage"
Console.WriteLine($"Endpoint: {chatMetadata?.ProviderUri}");

var embeddingMetadata = Meai.EmbeddingGeneratorExtensions.GetService<Meai.EmbeddingGeneratorMetadata>(generator);
Console.WriteLine($"Provider: {embeddingMetadata?.ProviderName}"); // "upstage"
```
