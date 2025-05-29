namespace Api.TorMarket.Domain.Models.ViewModels;

public record UserWithRole : User
{
    public required Role Role { get; init; }
}