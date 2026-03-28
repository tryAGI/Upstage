# CLAUDE.md -- Upstage SDK

## Overview

Auto-generated C# SDK for [Upstage](https://upstage.ai/) -- Korean AI platform offering Solar LLM for chat completions, embeddings, Document AI (parsing, OCR, layout analysis), groundedness checking, and translation.
**No public OpenAPI spec exists** -- `openapi.yaml` was manually created from Upstage API documentation.

## Build & Test

```bash
dotnet build Upstage.slnx
dotnet test src/tests/IntegrationTests/
```

## Auth

Bearer token auth:

```csharp
var client = new UpstageClient(apiKey); // UPSTAGE_API_KEY env var
```

## Key Files

- `src/libs/Upstage/openapi.yaml` -- **Manually maintained** OpenAPI spec (no public spec from Upstage)
- `src/libs/Upstage/generate.sh` -- Runs autosdk on local spec (no download step)
- `src/libs/Upstage/Generated/` -- **Never edit** -- auto-generated code
- `src/tests/IntegrationTests/` -- Integration tests
- `src/tests/IntegrationTests/Examples/` -- Example tests (also generate docs)

## Sub-Client Pattern

```csharp
var client = new UpstageClient(apiKey);

// Chat completions (Solar LLM)
client.Chat.CreateChatCompletionAsync(...)

// Embeddings
client.Embeddings.CreateEmbeddingAsync(...)

// Document AI
client.DocumentAI.DocumentParseAsync(...)
client.DocumentAI.DocumentOcrAsync(...)
client.DocumentAI.LayoutAnalysisAsync(...)

// Groundedness Check
client.GroundednessCheck.GroundednessCheckAsync(...)

// Translation
client.Translation.TranslateAsync(...)
```

## Spec Notes

- **No public OpenAPI spec exists** -- `openapi.yaml` was manually created from Upstage developer docs
- 7 endpoints across 5 tags: Chat, Embeddings, DocumentAI, GroundednessCheck, Translation
- Auth: Standard `http/bearer` scheme defined in spec (no jq/yq fix needed)
- Base URL: `https://api.upstage.ai/v1`
- Document AI endpoints use `multipart/form-data` for file upload
- Chat completions API is OpenAI-compatible
