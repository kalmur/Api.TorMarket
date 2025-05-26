namespace Api.TorMarket.Persistence.Entities;

internal class ListingEntity : AuditableEntity
{
    internal const int ListingEntity_NameMaxLength = 100;
    internal const int ListingEntity_DescriptionMaxLength = 250;

    internal int ListingId { get; set; }
    internal required int UserId { get; set; }
    internal required int CategoryId { get; set; }
    internal required string Name { get; set; }
    internal required decimal Price { get; set; }
    internal required string? Description { get; set; }
    internal required List<string>? BlobUrls { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingCategoryEntity ListingCategory { get; set; } = null!;

    internal virtual IEnumerable<ListingReviewEntity> ListingReviews { get; set; } = null!;
    internal virtual IEnumerable<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
    internal virtual IEnumerable<OrderLineEntity> OrderLines { get; set; } = null!;
}
