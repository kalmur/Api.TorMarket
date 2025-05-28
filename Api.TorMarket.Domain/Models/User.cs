namespace Api.TorMarket.Domain.Models;

public record User
{
    public const int ProviderId_MaxLength = 20;

    public required int UserId { get; init; }
    public required string ProviderId { get; init; }
}
