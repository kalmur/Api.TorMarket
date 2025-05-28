namespace Api.TorMarket.Persistence.Entities;

internal class ListingEntity : AuditableEntity
{
    internal int ListingId { get; set; }
    internal required int UserId { get; set; }
    internal required int CategoryId { get; set; }
    internal required string Name { get; set; }
    internal required decimal Price { get; set; }
    internal required string? Description { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual ListingCategoryEntity ListingCategory { get; set; } = null!;

    internal virtual ICollection<ListingBlobEntity> ListingBlobs { get; set; } = null!;
    internal virtual ICollection<ListingReviewEntity> UserProductReviews { get; set; } = null!;
    internal virtual ICollection<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
    internal virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
