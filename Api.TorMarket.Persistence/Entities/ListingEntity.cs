namespace Api.TorMarket.Persistence.Entities;

internal class ListingEntity : AuditableEntity
{
    public int ListingId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset AvailableFrom { get; set; }

    // Add image later down the line

    public virtual UserEntity User { get; set; } = null!;
    public virtual ListingCategoryEntity ProductCategoryEntity { get; set; } = null!;
    public virtual ICollection<ListingReviewEntity> UserProductReviews { get; set; } = null!;
    public virtual ICollection<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
    public virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
