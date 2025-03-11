namespace Api.TorMarket.WebApi.DTOs.Responses;

public record FailureResponseDto
{
    public required IEnumerable<string> Errors { get; init; }
}