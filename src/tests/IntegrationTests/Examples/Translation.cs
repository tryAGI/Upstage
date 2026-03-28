/*
order: 50
title: Translation
slug: translation

Shows how to translate text between languages using Upstage Solar Translation models.
*/

namespace Upstage.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_TranslateText()
    {
        //// Create an authenticated client using your Upstage API key.
        using var client = GetAuthenticatedClient();

        //// Translate English text to Korean using the Solar translation model.
        //// The `TranslateAsync` method requires the model name, text, source language,
        //// and target language.
        var response = await client.Translation.TranslateAsync(
            model: "solar-1-mini-translate-enko",
            text: "Hello, how are you?",
            sourceLang: "en",
            targetLang: "ko");

        //// The response contains the translated text along with the detected
        //// source language and the target language.
        response.Should().NotBeNull();
        response.Output.Should().NotBeNull();
        response.Output!.Text.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Translated text: {response.Output.Text}");
        Console.WriteLine($"Source language: {response.Output.SourceLang}");
        Console.WriteLine($"Target language: {response.Output.TargetLang}");
    }
}
