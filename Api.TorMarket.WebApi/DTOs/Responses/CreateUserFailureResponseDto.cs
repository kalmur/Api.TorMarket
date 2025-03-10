namespace Api.TorMarket.WebApi.DTOs.Responses;

public record CreateUserFailureResponseDto
{
    public required IEnumerable<string> Errors { get; init; }
}
