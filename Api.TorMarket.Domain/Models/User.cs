namespace Api.TorMarket.Domain.Models;

public record User
{
    public const int ProviderIdMaxLength = 20;

    public required int UserId { get; set; }
    public required string ProviderId { get; set; }
}
