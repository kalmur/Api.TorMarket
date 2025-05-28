using Api.TorMarket.Persistence.Entities.Common;

namespace Api.TorMarket.Persistence.Entities;

internal class UserEntity : AuditableEntity
{
    internal int UserId { get; set; }
    internal required string ProviderId { get; set; }

    internal virtual ICollection<UserAddressEntity> Addresses { get; set; } = null!;
    internal virtual ICollection<ListingEntity> Listings { get; set; } = null!;
    internal virtual ICollection<ListingReviewEntity> ListingReviews { get; set; } = null!;
    internal virtual ICollection<OrderEntity> Orders { get; set; } = null!;
    internal virtual ICollection<ShoppingCartEntity> ShoppingCarts { get; set; } = null!;
}