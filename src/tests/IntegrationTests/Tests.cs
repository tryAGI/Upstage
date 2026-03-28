namespace Upstage.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static UpstageClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("UPSTAGE_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("UPSTAGE_API_KEY environment variable is not found.");

        var client = new UpstageClient(apiKey);
        
        return client;
    }
}
