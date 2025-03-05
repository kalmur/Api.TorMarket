namespace Api.TorMarket.Domain.Models;

public record SiteUser
{
    public required int UserId { get; set; }
    public required string ProviderId { get; set; }
}
