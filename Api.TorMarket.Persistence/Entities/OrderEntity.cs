namespace Api.TorMarket.Persistence.Entities;

public class OrderEntity : AuditableEntity
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ShippingAddress { get; set; }
    public int OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTimeOffset OrderDate { get; set; }

    public virtual UserEntity User { get; set; } = null!;
    public virtual UserAddressEntity Address { get; set; } = null!;
    public virtual OrderStatusEntity StatusEntity { get; set; } = null!;
    public virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
