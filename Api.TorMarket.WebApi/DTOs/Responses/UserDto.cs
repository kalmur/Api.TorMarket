namespace Api.TorMarket.WebApi.DTOs.Responses;

public record UserDto
{
    public required int UserId { get; init; }
    public required int RoleId { get; init; }
    public required string ProviderId { get; init; }
}
