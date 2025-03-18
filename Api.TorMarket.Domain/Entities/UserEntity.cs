using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class UserEntity : AuditableEntity
{
    public int UserId { get; set; }
    public string ProviderId { get; set; } = string.Empty;

    public virtual ICollection<UserAddressEntity> Addresses { get; set; } = null!;
    public virtual ICollection<ListingEntity> Products { get; set; } = null!;
    public virtual ICollection<ListingReviewEntity> ProductReviews { get; set; } = null!;
    public virtual ICollection<OrderEntity> Orders { get; set; } = null!;
    public virtual ICollection<ShoppingCartEntity> ShoppingCarts { get; set; } = null!;
}