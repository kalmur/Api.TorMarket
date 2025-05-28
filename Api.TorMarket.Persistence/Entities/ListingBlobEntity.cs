namespace Api.TorMarket.Persistence.Entities;

internal class ListingBlobEntity
{
    internal const int Url_MaxLength = 50;

    internal int ListingBlobId { get; set; }
    internal required int ListingId { get; set; }
    internal required string Url { get; set; }
    internal required bool IsPrimary { get; set; }

    internal virtual ListingEntity Listing { get; set; } = null!;
}
