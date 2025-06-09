namespace Api.TorMarket.Domain.Models.ViewModels;

public sealed record UserWithRole
{
    public required User User { get; init; }
    public required Role Role { get; init; }
}