#pragma warning disable CS3002 // Return type is not CLS-compliant
#nullable enable

using Microsoft.Extensions.AI;

namespace Upstage;

/// <summary>
/// Extensions for using UpstageClient as MEAI tools with any IChatClient.
/// </summary>
public static class UpstageToolExtensions
{
    /// <summary>
    /// Creates an <see cref="AIFunction"/> that wraps Upstage Groundedness Check,
    /// suitable for use as a tool with any IChatClient.
    /// Checks whether a given answer is grounded in the provided context.
    /// </summary>
    /// <param name="client">The Upstage client to use.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsGroundednessCheckTool(this UpstageClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string context, string answer, CancellationToken cancellationToken) =>
            {
                var response = await client.GroundednessCheck.GroundednessCheckAsync(
                    context: context,
                    answer: answer,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatGroundednessResponse(response);
            },
            name: "GroundednessCheck",
            description: "Checks whether a given answer/response is grounded in (factually supported by) the provided context text. Returns a boolean result, confidence score (0-1), and explanation. Useful for verifying that LLM responses are factually accurate based on source material.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that wraps Upstage Translation,
    /// suitable for use as a tool with any IChatClient.
    /// Translates text between languages using Solar translation models.
    /// </summary>
    /// <param name="client">The Upstage client to use.</param>
    /// <param name="defaultModel">Default translation model (default: solar-1-mini-translate-enko).</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsTranslateTool(
        this UpstageClient client,
        string defaultModel = "solar-1-mini-translate-enko")
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string text, string sourceLang, string targetLang, string? model, CancellationToken cancellationToken) =>
            {
                var response = await client.Translation.TranslateAsync(
                    model: model ?? defaultModel,
                    text: text,
                    sourceLang: sourceLang,
                    targetLang: targetLang,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatTranslationResponse(response);
            },
            name: "TranslateText",
            description: "Translates text from one language to another using Upstage Solar translation models. Pass source and target language codes (e.g., 'en', 'ko', 'ja'). Supports English-Korean and other language pairs.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that wraps Upstage Document Parse,
    /// suitable for use as a tool with any IChatClient.
    /// Parses documents (PDFs, images) and extracts structured content.
    /// </summary>
    /// <param name="client">The Upstage client to use.</param>
    /// <param name="outputFormats">Comma-separated output formats: html, markdown, text (default: html,text).</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsDocumentParseTool(
        this UpstageClient client,
        string outputFormats = "html,text")
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string base64Content, string filename, CancellationToken cancellationToken) =>
            {
                var fileBytes = Convert.FromBase64String(base64Content);

                var response = await client.DocumentAI.DocumentParseAsync(
                    document: fileBytes,
                    documentname: filename,
                    outputFormats: outputFormats,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatDocumentParseResponse(response);
            },
            name: "ParseDocument",
            description: "Parses a document file (PDF, PNG, JPG, JPEG, BMP, TIFF) and extracts structured content including text, HTML, and Markdown representations. Accepts base64-encoded file content and filename. Returns the parsed document content.");
    }

    private static string FormatGroundednessResponse(GroundednessCheckResponse response)
    {
        var parts = new List<string>();

        if (response.Grounded is { } grounded)
        {
            parts.Add($"Grounded: {grounded}");
        }

        if (response.Score is { } score)
        {
            parts.Add($"Confidence: {score:F2}");
        }

        if (response.Reason is { Length: > 0 } reason)
        {
            parts.Add($"Reason: {reason}");
        }

        return parts.Count > 0 ? string.Join("\n", parts) : "No groundedness check result returned.";
    }

    private static string FormatTranslationResponse(TranslationResponse response)
    {
        if (response.Output?.Text is { Length: > 0 } translatedText)
        {
            var parts = new List<string> { translatedText };

            if (response.Output.SourceLang is { Length: > 0 } src && response.Output.TargetLang is { Length: > 0 } tgt)
            {
                parts.Add($"({src} -> {tgt})");
            }

            return string.Join("\n", parts);
        }

        return "No translation returned.";
    }

    private static string FormatDocumentParseResponse(DocumentParseResponse response)
    {
        var parts = new List<string>();

        if (response.Content?.Text is { Length: > 0 } text)
        {
            parts.Add($"Text:\n{text}");
        }

        if (response.Content?.Markdown is { Length: > 0 } markdown)
        {
            parts.Add($"Markdown:\n{markdown}");
        }

        if (response.Content?.Html is { Length: > 0 } html)
        {
            parts.Add($"HTML:\n{html}");
        }

        if (response.Model is { Length: > 0 } model)
        {
            parts.Add($"Model: {model}");
        }

        return parts.Count > 0 ? string.Join("\n\n", parts) : "No document parse result returned.";
    }
}
