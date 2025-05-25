using Api.TorMarket.Infrastructure.Options;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace Api.TorMarket.Infrastructure.Tests.Options.Azure;

internal static class AzureConfigExtensions
{
    internal static void Value_Mock_ReturnsAzureConfig(
        this IOptions<AzureConfig> options,
        AzureConfig azureConfig = null
    ) => options.Value
        .Returns(
            azureConfig ?? AzureConfigGenerator.GenerateAzureConfig()
        );
}
