namespace Api.TorMarket.WebApi.DTOs.Responses.Failures;

public record FailureResponseDto
{
    public required IEnumerable<string> Errors { get; init; }
}