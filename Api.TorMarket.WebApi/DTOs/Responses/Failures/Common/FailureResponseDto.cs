namespace Api.TorMarket.WebApi.DTOs.Responses.Failures.Common;

public record FailureResponseDto
{
    public required IEnumerable<string> Errors { get; init; }
}