#!/usr/bin/env bash
set -euo pipefail

install_autosdk_cli() {
  dotnet tool update --global autosdk.cli --prerelease >/dev/null 2>&1 || \
    dotnet tool install --global autosdk.cli --prerelease
}

# OpenAPI spec: locally maintained (no public spec available)
install_autosdk_cli

rm -rf Generated

# Upstage has no public OpenAPI spec — openapi.yaml is manually maintained from docs.
# Auth: Bearer token (standard http/bearer scheme defined in spec).
# `stream: true` on chat completions returns server-sent events, and the spec declares only
# `application/json` - so the generator has no reason to emit a streaming method and a caller who
# sets the flag gets a parse failure instead of a stream. The event schema is already in the spec
# (`ChatCompletionChunkResponse`); only the content type was missing.
yq -i '.paths."/chat/completions".post.responses."200".content."text/event-stream".schema."$ref" = "#/components/schemas/ChatCompletionChunkResponse"' openapi.yaml

# yq exits 0 when its expression fails to parse, so verify the effect rather than the exit code.
if ! yq -e '.paths."/chat/completions".post.responses."200".content | has("text/event-stream")' openapi.yaml >/dev/null; then
  echo "error: the streaming content-type patch did not apply to openapi.yaml." >&2
  exit 1
fi

autosdk generate openapi.yaml \
  --namespace Upstage \
  --clientClassName UpstageClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
