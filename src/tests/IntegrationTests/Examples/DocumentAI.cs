/*
order: 30
title: Document AI
slug: document-ai

Shows how to use Upstage Document AI for parsing documents and performing OCR.
These tests require file uploads and are skipped unless a test document is available.
*/

namespace Upstage.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_DocumentParse()
    {
        //// Create an authenticated client using your Upstage API key.
        using var client = GetAuthenticatedClient();

        //// Document Parse requires a file upload. We create a simple text file
        //// to demonstrate the API call. In production, you would use PDF or image files.
        var documentBytes = "Hello, this is a test document for parsing."u8.ToArray();

        //// Parse the document using the `DocumentParseAsync` method.
        //// The method accepts the file bytes, filename, and optional parameters like
        //// OCR mode and output formats.
        var response = await client.DocumentAI.DocumentParseAsync(
            document: documentBytes,
            documentname: "test.txt",
            ocr: DocumentParseRequestOcr.Auto,
            outputFormats: "text");

        //// The response contains the parsed content in the requested formats
        //// (HTML, Markdown, text) along with individual document elements.
        response.Should().NotBeNull();
        response.Content.Should().NotBeNull();

        Console.WriteLine($"API: {response.Api}");
        Console.WriteLine($"Model: {response.Model}");
    }

    [TestMethod]
    public async Task Example_DocumentOcr()
    {
        //// Create an authenticated client using your Upstage API key.
        using var client = GetAuthenticatedClient();

        //// Document OCR requires a file upload. We create a simple text file
        //// to demonstrate the API call. In production, you would use scanned PDFs or images.
        var documentBytes = "Hello, this is a test document for OCR."u8.ToArray();

        //// Perform OCR on the document using the `DocumentOcrAsync` method.
        //// OCR extracts text with word-level bounding boxes and confidence scores.
        var response = await client.DocumentAI.DocumentOcrAsync(
            document: documentBytes,
            documentname: "test.txt");

        //// The response contains the extracted text and page-level OCR results.
        response.Should().NotBeNull();

        Console.WriteLine($"API: {response.Api}");
        Console.WriteLine($"Model: {response.Model}");
        Console.WriteLine($"Extracted text: {response.Text}");
    }
}
