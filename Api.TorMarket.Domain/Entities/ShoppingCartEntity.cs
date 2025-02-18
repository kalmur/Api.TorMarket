namespace Api.TorMarket.Domain.Entities;

public class ShoppingCartEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public virtual SiteUserEntity User { get; set; } = null!;
    public virtual ICollection<ShoppingCartItemEntity> Items { get; set; } = null!;
}
