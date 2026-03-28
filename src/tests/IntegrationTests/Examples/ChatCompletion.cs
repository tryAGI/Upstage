/*
order: 10
title: Chat Completion
slug: chat-completion

Shows how to use the Upstage Solar LLM for chat completions.
*/

namespace Upstage.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_CreateChatCompletion()
    {
        //// Create an authenticated client using your Upstage API key.
        using var client = GetAuthenticatedClient();

        //// Send a simple chat message to the Solar Mini model.
        //// The `CreateChatCompletionAsync` method accepts a model name and a list of messages.
        var response = await client.Chat.CreateChatCompletionAsync(
            model: "solar-mini",
            messages: [
                new ChatMessage
                {
                    Role = ChatMessageRole.System,
                    Content = "You are a helpful assistant.",
                },
                new ChatMessage
                {
                    Role = ChatMessageRole.User,
                    Content = "Hello! What is Upstage?",
                },
            ]);

        //// The response contains a unique ID, the model used, and a list of choices.
        //// Each choice has a message with the assistant's reply.
        response.Id.Should().NotBeNullOrEmpty();
        response.Choices.Should().NotBeNullOrEmpty();
        response.Choices![0].Message.Should().NotBeNull();
        response.Choices[0].Message!.Content.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Response: {response.Choices[0].Message!.Content}");
    }
}
