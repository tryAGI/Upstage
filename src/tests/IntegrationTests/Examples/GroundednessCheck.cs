/*
order: 40
title: Groundedness Check
slug: groundedness-check

Shows how to verify whether an answer is grounded in a given context
using the Upstage Groundedness Check API.
*/

namespace Upstage.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_CheckGroundedness()
    {
        //// Create an authenticated client using your Upstage API key.
        using var client = GetAuthenticatedClient();

        //// Define the context (source material) and an answer to verify.
        //// The groundedness check determines whether the answer is supported by the context.
        var context = "Upstage is a leading AI company based in South Korea. " +
                      "They develop Solar LLM, a large language model optimized for " +
                      "various natural language processing tasks.";
        var answer = "Upstage is a South Korean AI company that created Solar LLM.";

        //// Call the `GroundednessCheckAsync` method with the context and answer.
        //// You can optionally specify a model (default is "groundedness-check").
        var response = await client.GroundednessCheck.GroundednessCheckAsync(
            context: context,
            answer: answer);

        //// The response includes a boolean `Grounded` field, a confidence `Score`
        //// between 0 and 1, and a `Reason` explaining the determination.
        response.Should().NotBeNull();
        response.Id.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Grounded: {response.Grounded}");
        Console.WriteLine($"Score: {response.Score}");
        Console.WriteLine($"Reason: {response.Reason}");
    }
}
