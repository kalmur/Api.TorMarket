namespace Api.TorMarket.Persistence.Entities;

internal class OrderStatusEntity
{
    internal int OrderStatusId { get; set; }
    internal string Status { get; set; } = string.Empty;

    internal virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}
