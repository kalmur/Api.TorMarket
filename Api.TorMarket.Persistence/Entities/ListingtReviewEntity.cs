namespace Api.TorMarket.Persistence.Entities;

internal class ListingReviewEntity : AuditableEntity
{
    internal int UserId { get; set; }
    internal int ListingId { get; set; }
    internal int RatingValue { get; set; }
    internal string Comment { get; set; } = string.Empty;

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingEntity Listing { get; set; } = null!;
}
