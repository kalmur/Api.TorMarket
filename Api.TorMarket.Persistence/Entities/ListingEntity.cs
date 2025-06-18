using Api.TorMarket.Persistence.Entities.Common;

namespace Api.TorMarket.Persistence.Entities;

internal class ListingEntity : AuditableEntity
{
    internal int ListingId { get; set; }
    internal required int UserId { get; set; }
    internal required int CategoryId { get; set; }
    internal required int CurrencyId { get; set; }

    internal required string Title { get; set; }
    internal required decimal Price { get; set; }
    internal required string? Description { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual CurrencyEntity Currency { get; set; } = null!;
    internal virtual CategoryEntity Category { get; set; } = null!;

    internal virtual ICollection<ListingBlobEntity> ListingBlobs { get; set; } = null!;
    internal virtual ICollection<ListingReviewEntity> ListingReviews { get; set; } = null!;
    internal virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
    internal virtual ICollection<ShoppingCartItemEntity> ShoppingCartItems { get; set; } = null!;
}
