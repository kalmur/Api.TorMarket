namespace Api.TorMarket.Persistence.Entities;

internal class ListingEntity : AuditableEntity
{
    internal int ListingId { get; set; }
    internal int UserId { get; set; }
    internal int CategoryId { get; set; }
    internal string? Name { get; set; }
    internal decimal Price { get; set; }
    internal string? Description { get; set; }
    internal DateTimeOffset AvailableFrom { get; set; }

    // Add image later down the line

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingCategoryEntity ListingCategory { get; set; } = null!;
    internal virtual ICollection<ListingReviewEntity> UserProductReviews { get; set; } = null!;
    internal virtual ICollection<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
    internal virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
