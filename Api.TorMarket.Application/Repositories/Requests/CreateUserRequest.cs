namespace Api.TorMarket.Application.Repositories.Requests;

public sealed record CreateUserRequest
{
    public required int RoleId { get; init; }
    public required string ProviderId { get; init; }
}