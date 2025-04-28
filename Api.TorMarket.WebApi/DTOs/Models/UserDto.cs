namespace Api.TorMarket.WebApi.DTOs.Models;

public record UserDto
{
    public required int UserId { get; init; }
    public required string ProviderId { get; init; }
}
