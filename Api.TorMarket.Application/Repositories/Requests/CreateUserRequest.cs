namespace Api.TorMarket.Application.Repositories.Requests;

public sealed record CreateUserRequest
{
    public required string ProviderId { get; init; }
}