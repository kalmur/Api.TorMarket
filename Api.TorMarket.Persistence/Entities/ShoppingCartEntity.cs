namespace Api.TorMarket.Persistence.Entities;

internal class ShoppingCartEntity
{
    internal int ShoppingCartId { get; set; }
    internal required int UserId { get; set; }

    internal virtual UserEntity User { get; set; } = null!;

    internal virtual ICollection<ShoppingCartItemEntity> Items { get; set; } = null!;
}
