#nullable enable

namespace Upstage
{
    public partial interface IGroundednessCheckClient
    {
        /// <summary>
        /// Groundedness check<br/>
        /// Checks whether a given answer is grounded in the provided context.<br/>
        /// Returns a boolean result, confidence score, and reason.<br/>
        /// Useful for verifying that LLM responses are factually supported by source material.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Upstage.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Upstage.GroundednessCheckResponse> GroundednessCheckAsync(

            global::Upstage.GroundednessCheckRequest request,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Groundedness check<br/>
        /// Checks whether a given answer is grounded in the provided context.<br/>
        /// Returns a boolean result, confidence score, and reason.<br/>
        /// Useful for verifying that LLM responses are factually supported by source material.
        /// </summary>
        /// <param name="context">
        /// The context/source text against which the answer will be verified.
        /// </param>
        /// <param name="answer">
        /// The answer/response to check for groundedness.
        /// </param>
        /// <param name="model">
        /// The model to use for groundedness check.<br/>
        /// Default: groundedness-check<br/>
        /// Default Value: groundedness-check
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Upstage.GroundednessCheckResponse> GroundednessCheckAsync(
            string context,
            string answer,
            string? model = default,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}