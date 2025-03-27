namespace Api.TorMarket.Persistence.Entities;

internal class ShoppingCartEntity
{
    public int ShoppingCartId { get; set; }
    public int UserId { get; set; }

    public virtual UserEntity User { get; set; } = null!;
    public virtual ICollection<ShoppingCartItemEntity> Items { get; set; } = null!;
}
