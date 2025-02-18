namespace Api.TorMarket.Domain.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public int SellLease { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }

    public virtual SiteUserEntity User { get; set; } = null!;
    public virtual ProductCategoryEntity ProductCategoryEntity { get; set; } = null!;
    public virtual ICollection<ProductReviewEntity> UserProductReviews { get; set; } = null!;
    public virtual ICollection<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
    public virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
