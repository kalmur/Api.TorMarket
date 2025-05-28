namespace Api.TorMarket.Domain.Models;

public record ListingBlob
{
    public const int Url_MaxLength = 50;

    public int ListingBlobId { get; init; }
    public required int ListingId { get; init; }
    public required string Url { get; init; }
    public required bool IsPrimary { get; init; }
}
