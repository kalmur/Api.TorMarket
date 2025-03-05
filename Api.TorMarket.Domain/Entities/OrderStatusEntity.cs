namespace Api.TorMarket.Domain.Entities;

public class OrderStatusEntity
{
    public int OrderStatusId { get; set; }
    public string? Status { get; set; }

    public virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}
