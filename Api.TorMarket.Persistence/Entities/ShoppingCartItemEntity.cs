namespace Api.TorMarket.Persistence.Entities;

internal class ShoppingCartItemEntity
{
    internal int ShoppingCartItemId { get; set; }
    internal int CartId { get; set; }
    internal int ProductId { get; set; }
    internal int Quantity { get; set; }

    internal virtual ShoppingCartEntity ShoppingCart { get; set; } = null!;
    internal virtual ListingEntity Product { get; set; } = null!;
}