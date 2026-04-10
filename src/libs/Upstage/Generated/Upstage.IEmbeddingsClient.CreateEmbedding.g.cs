#nullable enable

namespace Upstage
{
    public partial interface IEmbeddingsClient
    {
        /// <summary>
        /// Create embedding<br/>
        /// Creates an embedding vector representing the input text.<br/>
        /// Supports Solar Embedding models for passage and query embeddings.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Upstage.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Upstage.EmbeddingResponse> CreateEmbeddingAsync(

            global::Upstage.EmbeddingRequest request,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create embedding<br/>
        /// Creates an embedding vector representing the input text.<br/>
        /// Supports Solar Embedding models for passage and query embeddings.
        /// </summary>
        /// <param name="model">
        /// The model to use for generating embeddings.<br/>
        /// Available models: solar-embedding-1-large, solar-embedding-1-large-passage,<br/>
        /// solar-embedding-1-large-query<br/>
        /// Example: solar-embedding-1-large
        /// </param>
        /// <param name="input">
        /// Input text to embed. Can be a string or array of strings.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Upstage.EmbeddingResponse> CreateEmbeddingAsync(
            string model,
            global::Upstage.OneOf<string, global::System.Collections.Generic.IList<string>> input,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}