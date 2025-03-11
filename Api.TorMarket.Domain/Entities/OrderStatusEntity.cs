namespace Api.TorMarket.Domain.Entities;

public class OrderStatusEntity
{
    public int OrderStatusId { get; set; }
    public string Status { get; set; } = string.Empty;

    public virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}
