namespace Api.TorMarket.Persistence.Entities;

internal class ListingEntity : AuditableEntity
{
    // TODO Check this and in extension
    internal int ListingId { get; set; }
    internal required int UserId { get; set; }
    internal required int CategoryId { get; set; }
    internal required string Name { get; set; }
    internal required decimal Price { get; set; }
    internal required string? Description { get; set; }
    internal required List<string>? ImageUrls { get; set; }

    // Add image later down the line

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingCategoryEntity ListingCategory { get; set; } = null!;

    internal virtual IEnumerable<ListingReviewEntity> UserProductReviews { get; set; } = null!;
    internal virtual IEnumerable<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
    internal virtual IEnumerable<OrderLineEntity> OrderLines { get; set; } = null!;
}
