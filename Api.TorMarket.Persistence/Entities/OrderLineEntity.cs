namespace Api.TorMarket.Persistence.Entities;

internal class OrderLineEntity
{
    internal int OrderLineId { get; set; }
    internal int ListingId { get; set; }
    internal int OrderId { get; set; }
    internal int Quantity { get; set; }
    internal decimal Price { get; set; }

    internal virtual ListingEntity Listing { get; set; } = null!;
    internal virtual OrderEntity Order { get; set; } = null!;
}
