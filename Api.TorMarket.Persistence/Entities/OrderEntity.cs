namespace Api.TorMarket.Persistence.Entities;

internal class OrderEntity : AuditableEntity
{
    internal int OrderId { get; set; }
    internal int UserId { get; set; }
    internal int StatusId { get; set; }
    internal int ShippingAddress { get; set; }
    internal decimal TotalPrice { get; set; }
    internal DateTimeOffset OrderDate { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual UserAddressEntity UserAddress { get; set; } = null!;
    internal virtual OrderStatusEntity OrderStatus { get; set; } = null!;

    internal virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
