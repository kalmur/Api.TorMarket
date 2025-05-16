using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace Api.TorMarket.Infrastructure.Options;

public record AzureConfig
{
    public const string SectionName = "Azure";

    [Required]
    public required string AccessKey { get; init; }

    [Required]
    public required string ConnectionString { get; init; }

    [Required]
    public required string StorageAccountName { get; init; }

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
