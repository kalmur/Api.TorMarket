namespace Api.TorMarket.Persistence.Entities;

internal class ShoppingCartItemEntity
{
    public int ShoppingCartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual ShoppingCartEntity ShoppingCart { get; set; } = null!;
    public virtual ListingEntity Product { get; set; } = null!;
}