namespace Api.TorMarket.Domain.Entities;

public class OrderLineEntity
{
    public int OrderLineId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public virtual ListingEntity Product { get; set; } = null!;
    public virtual OrderEntity Order { get; set; } = null!;
}
