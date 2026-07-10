using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace Api.TorMarket.Infrastructure.Options;

internal record AzureConfig
{
    internal const string SectionName = "Azure";

    [Required(AllowEmptyStrings = false)]
    public required string AccessKey { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ConnectionString { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string StorageAccountName { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ListingsContainerName { get; init; }

    public string? TextAnalyticsEndpoint { get; init; }

    public string? TextAnalyticsApiKey { get; init; }

    internal static IConfigurationSection GetAzureConfig(
        IConfiguration configuration
    ) => configuration.GetSection(SectionName);

    internal static AzureConfig LoadFromConfiguration(
        IConfiguration configuration
    )
    {
        var azureConfig = GetAzureConfig(configuration)
                              .Get<AzureConfig>()
                          ?? throw new InvalidOperationException(
                              $"Missing {SectionName} configuration section"
                          );

        Validator.ValidateObject(
            azureConfig,
            new ValidationContext(azureConfig),
            validateAllProperties: true
        );

        return azureConfig;
    }
}
