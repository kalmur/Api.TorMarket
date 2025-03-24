namespace Api.TorMarket.Persistence.Entities;

public class OrderStatusEntity
{
    public int OrderStatusId { get; set; }
    public string Status { get; set; } = string.Empty;

    public virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}
