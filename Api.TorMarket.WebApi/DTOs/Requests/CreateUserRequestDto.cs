namespace Api.TorMarket.WebApi.DTOs.Requests;

public record CreateUserRequestDto
{
    public required string ProviderId { get; init; }
}