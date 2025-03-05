namespace Api.TorMarket.Domain.Entities;

public class SiteUserEntity
{
    public int UserId { get; set; }
    public string? ProviderId { get; set; }

    public virtual ICollection<UserAddressEntity> Addresses { get; set; } = null!;
    public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    public virtual ICollection<ProductReviewEntity> ProductReviews { get; set; } = null!;
    public virtual ICollection<OrderEntity> Orders { get; set; } = null!;
    public virtual ICollection<ShoppingCartEntity> ShoppingCarts { get; set; } = null!;
}
