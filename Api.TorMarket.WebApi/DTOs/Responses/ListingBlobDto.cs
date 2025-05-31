namespace Api.TorMarket.WebApi.DTOs.Responses;

public sealed record class ListingBlobDto
{
    public required string Url { get; init; }
    public required bool IsPrimary { get; init; }
}
