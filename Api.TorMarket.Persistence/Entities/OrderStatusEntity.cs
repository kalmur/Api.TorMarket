namespace Api.TorMarket.Persistence.Entities;

internal class OrderStatusEntity
{
    internal int OrderStatusId { get; set; }
    internal required string Status { get; set; }

    internal virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}
