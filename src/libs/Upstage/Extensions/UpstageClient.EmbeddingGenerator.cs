#nullable enable

using Meai = Microsoft.Extensions.AI;

namespace Upstage;

public partial class UpstageClient : Meai.IEmbeddingGenerator<string, Meai.Embedding<float>>
{
    private Meai.EmbeddingGeneratorMetadata? _embeddingMetadata;

    /// <inheritdoc />
    object? Meai.IEmbeddingGenerator.GetService(Type serviceType, object? serviceKey)
    {
        ArgumentNullException.ThrowIfNull(serviceType);

        return
            serviceKey is not null ? null :
            serviceType == typeof(Meai.EmbeddingGeneratorMetadata)
                ? (_embeddingMetadata ??= new("upstage", BaseUri))
                : serviceType.IsInstanceOfType(this) ? this
                : null;
    }

    /// <inheritdoc />
    async Task<Meai.GeneratedEmbeddings<Meai.Embedding<float>>>
        Meai.IEmbeddingGenerator<string, Meai.Embedding<float>>.GenerateAsync(
            IEnumerable<string> values,
            Meai.EmbeddingGenerationOptions? options,
            CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(values);

        var textList = values.ToList();

        var request = new EmbeddingRequest
        {
            Model = options?.ModelId ?? "embedding-query",
            Input = textList.Count == 1
                ? new OneOf<string, IList<string>>(textList[0])
                : new OneOf<string, IList<string>>(textList),
        };

        var response = await Embeddings.CreateEmbeddingAsync(request, cancellationToken).ConfigureAwait(false);

        var embeddings = new Meai.GeneratedEmbeddings<Meai.Embedding<float>>();

        if (response.Data is { } data)
        {
            foreach (var item in data)
            {
                if (item.Embedding is { } embeddingList)
                {
                    var floatArray = new float[embeddingList.Count];
                    for (var i = 0; i < embeddingList.Count; i++)
                    {
                        floatArray[i] = (float)embeddingList[i];
                    }

                    embeddings.Add(new Meai.Embedding<float>(floatArray)
                    {
                        ModelId = response.Model,
                    });
                }
            }
        }

        if (response.Usage is { } usage)
        {
            embeddings.Usage = new Meai.UsageDetails
            {
                InputTokenCount = usage.PromptTokens,
                TotalTokenCount = usage.TotalTokens,
            };
        }

        return embeddings;
    }
}
