namespace Api.TorMarket.Domain.Entities;

public class OrderLine
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public virtual Product Product { get; set; } = null!;
    public virtual Order Order { get; set; } = null!;
}
