/*
order: 20
title: Embeddings
slug: embeddings

Shows how to generate text embeddings using Upstage Solar Embedding models.
*/

namespace Upstage.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_CreateEmbedding()
    {
        //// Create an authenticated client using your Upstage API key.
        using var client = GetAuthenticatedClient();

        //// Generate an embedding for a text input using the Solar Embedding model.
        //// The `input` parameter accepts a string or an array of strings.
        var response = await client.Embeddings.CreateEmbeddingAsync(
            model: "solar-embedding-1-large",
            input: "Upstage is a leading AI company.");

        //// The response contains a list of embedding data objects,
        //// each with a vector of floating-point numbers.
        response.Data.Should().NotBeNullOrEmpty();
        response.Data![0].Embedding.Should().NotBeNullOrEmpty();
        response.Model.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Model: {response.Model}");
        Console.WriteLine($"Embedding dimensions: {response.Data[0].Embedding!.Count}");
    }
}
