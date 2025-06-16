using Api.TorMarket.Persistence.Entities.Common;

namespace Api.TorMarket.Persistence.Entities;

internal class ListingReviewEntity : AuditableEntity
{
    internal required int UserId { get; set; }
    internal required int ListingId { get; set; }

    internal required int Rating { get; set; }
    internal required string? Comment { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingEntity Listing { get; set; } = null!;
}
