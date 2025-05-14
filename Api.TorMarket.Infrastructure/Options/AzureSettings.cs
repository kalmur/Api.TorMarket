using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Infrastructure.Options;

public record AzureSettings
{
    public const string SectionName = "Azure";

    [Required]
    public required string AccessKey { get; init; }

    [Required]
    public required string ConnectionString { get; init; }

    [Required]
    public required string StorageAccountName { get; init; }
   
}
