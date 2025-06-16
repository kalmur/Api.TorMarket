namespace Api.TorMarket.WebApi.DTOs.Responses;

public sealed record ListingBlobDto
{
    public required string Url { get; init; }
    public required bool IsPrimary { get; init; }
}
