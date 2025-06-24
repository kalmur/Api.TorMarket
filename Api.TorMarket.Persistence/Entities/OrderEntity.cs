using Api.TorMarket.Persistence.Entities.Common;

namespace Api.TorMarket.Persistence.Entities;

internal class OrderEntity : AuditableEntity
{
    internal int OrderId { get; set; }
    internal required int UserId { get; set; }
    internal required int OrderStatusId { get; set; }

    internal required decimal TotalPrice { get; set; }
    internal required DateTimeOffset OrderDate { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
    internal virtual UserAddressEntity UserAddress { get; set; } = null!;
    internal virtual OrderStatusEntity OrderStatus { get; set; } = null!;

    internal virtual ICollection<OrderLineEntity> OrderLines { get; set; } = null!;
}
