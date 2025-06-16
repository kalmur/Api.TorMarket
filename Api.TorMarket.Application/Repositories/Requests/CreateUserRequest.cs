namespace Api.TorMarket.Application.Repositories.Requests;

public sealed record CreateUserRequest
{
    public required int RoleId { get; set; }
    public required string ProviderId { get; set; }
}