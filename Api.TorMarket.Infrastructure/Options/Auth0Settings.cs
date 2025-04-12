using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Infrastructure.Options;

public record Auth0Settings
{
    public const string SectionName = "Auth0";

    [Required]
    public required string Domain { get; set; }
    [Required]
    public required string ClientId { get; set; }
    [Required]
    public required string ClientSecret { get; set; }
    [Required]
    public required string Connection { get; set; }
}
