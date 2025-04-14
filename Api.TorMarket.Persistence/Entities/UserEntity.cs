namespace Api.TorMarket.Persistence.Entities;

internal class UserEntity : AuditableEntity
{
    internal int UserId { get; set; }
    internal string ProviderId { get; set; } = string.Empty;

    internal virtual ICollection<UserAddressEntity> Addresses { get; set; } = null!;
    internal virtual ICollection<ListingEntity> Products { get; set; } = null!;
    internal virtual ICollection<ListingReviewEntity> ProductReviews { get; set; } = null!;
    internal virtual ICollection<OrderEntity> Orders { get; set; } = null!;
    internal virtual ICollection<ShoppingCartEntity> ShoppingCarts { get; set; } = null!;
}