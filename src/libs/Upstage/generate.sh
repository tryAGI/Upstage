#!/usr/bin/env bash
set -euo pipefail

# OpenAPI spec: locally maintained (no public spec available)

dotnet tool update --global autosdk.cli --prerelease || dotnet tool install --global autosdk.cli --prerelease

rm -rf Generated

# Upstage has no public OpenAPI spec — openapi.yaml is manually maintained from docs.
# Auth: Bearer token (standard http/bearer scheme defined in spec).
autosdk generate openapi.yaml \
  --namespace Upstage \
  --clientClassName UpstageClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
