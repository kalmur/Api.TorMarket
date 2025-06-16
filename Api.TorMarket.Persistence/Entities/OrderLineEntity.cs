namespace Api.TorMarket.Persistence.Entities;

internal class OrderLineEntity
{
    internal int OrderLineId { get; set; }
    internal required int ListingId { get; set; }
    internal required int OrderId { get; set; }

    internal required int Quantity { get; set; }
    internal required decimal Price { get; set; }

    internal virtual ListingEntity Listing { get; set; } = null!;
    internal virtual OrderEntity Order { get; set; } = null!;
}
