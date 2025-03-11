namespace Api.TorMarket.Application.Repositories.Requests;

public record CreateUserRequest
{
    public required string ProviderId { get; init; }
}