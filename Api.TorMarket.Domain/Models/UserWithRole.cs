namespace Api.TorMarket.Domain.Models;

public record UserWithRole : User
{
    public required Role Role { get; init; }
}