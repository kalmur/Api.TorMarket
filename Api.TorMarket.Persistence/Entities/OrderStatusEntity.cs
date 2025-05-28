namespace Api.TorMarket.Persistence.Entities;

internal class OrderStatusEntity
{
    internal const int OrderStatusEntity_StatusMaxLength = 50;

    internal int OrderStatusId { get; set; }
    internal required string Status { get; set; }

    internal virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}
