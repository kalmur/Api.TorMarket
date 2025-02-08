namespace Api.TorMarket.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ShippingAddress { get; set; }
    public int OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    public virtual SiteUser User { get; set; } = null!;
    public virtual Address Address { get; set; } = null!;
    public virtual OrderStatus Status { get; set; } = null!;
}
