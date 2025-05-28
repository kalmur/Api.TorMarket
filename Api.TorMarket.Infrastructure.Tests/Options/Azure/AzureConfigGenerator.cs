using Api.TorMarket.Infrastructure.Options;

namespace Api.TorMarket.Infrastructure.Tests.Options.Azure;

internal static class AzureConfigGenerator
{
    internal static AzureConfig GenerateAzureConfig(
        string accessKey = null,
        string connectionString = null,
        string listingsContainerName = null,
        string storageAccountName = null
    ) => new()
    {
        AccessKey = accessKey,
        ConnectionString = connectionString,
        ListingsContainerName = listingsContainerName,
        StorageAccountName = storageAccountName
    };
}
