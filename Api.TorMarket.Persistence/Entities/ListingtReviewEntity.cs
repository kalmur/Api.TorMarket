namespace Api.TorMarket.Persistence.Entities;

internal class ListingReviewEntity : AuditableEntity
{
    internal int ListingReviewId { get; set; }
    internal int UserId { get; set; }
    internal int ProductId { get; set; }
    internal int RatingValue { get; set; }
    internal string Comment { get; set; } = string.Empty;

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingEntity Product { get; set; } = null!;
}
