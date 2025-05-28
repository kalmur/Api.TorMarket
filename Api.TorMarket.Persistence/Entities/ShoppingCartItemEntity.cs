namespace Api.TorMarket.Persistence.Entities;

internal class ShoppingCartItemEntity
{
    internal int ShoppingCartItemId { get; set; }
    internal required int CartId { get; set; }
    internal required int ProductId { get; set; }
    internal required int Quantity { get; set; }

    internal virtual ShoppingCartEntity ShoppingCart { get; set; } = null!;
    internal virtual ListingEntity Listing { get; set; } = null!;
}