#nullable enable

namespace Upstage
{
    public partial interface IDocumentAIClient
    {
        /// <summary>
        /// Document OCR<br/>
        /// Performs Optical Character Recognition (OCR) on documents.<br/>
        /// Extracts text content with word-level bounding boxes and confidence scores.<br/>
        /// Supports PDF and image files.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Upstage.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Upstage.OcrResponse> DocumentOcrAsync(

            global::Upstage.DocumentOcrRequest request,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Document OCR<br/>
        /// Performs Optical Character Recognition (OCR) on documents.<br/>
        /// Extracts text content with word-level bounding boxes and confidence scores.<br/>
        /// Supports PDF and image files.
        /// </summary>
        /// <param name="document">
        /// The document file to perform OCR on (PDF, PNG, JPG, JPEG, BMP, TIFF).
        /// </param>
        /// <param name="documentname">
        /// The document file to perform OCR on (PDF, PNG, JPG, JPEG, BMP, TIFF).
        /// </param>
        /// <param name="model">
        /// The model to use for OCR.<br/>
        /// Default: ocr<br/>
        /// Default Value: ocr
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Upstage.OcrResponse> DocumentOcrAsync(
            byte[] document,
            string documentname,
            string? model = default,
            global::Upstage.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}