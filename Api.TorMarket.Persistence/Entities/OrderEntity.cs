namespace Api.TorMarket.Persistence.Entities;

internal class OrderEntity : AuditableEntity
{
    internal int OrderId { get; set; }
    internal int UserId { get; set; }
    internal int ShippingAddress { get; set; }
    internal int OrderStatus { get; set; }
    internal decimal TotalPrice { get; set; }
    internal DateTimeOffset OrderDate { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual UserAddressEntity Address { get; set; } = null!;
    internal virtual OrderStatusEntity StatusEntity { get; set; } = null!;
    internal virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
