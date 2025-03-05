namespace Api.TorMarket.Domain.Entities;

public class OrderEntity
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ShippingAddress { get; set; }
    public int OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTimeOffset OrderDate { get; set; }

    public virtual SiteUserEntity User { get; set; } = null!;
    public virtual UserAddressEntity Address { get; set; } = null!;
    public virtual OrderStatusEntity StatusEntity { get; set; } = null!;
}
