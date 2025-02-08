namespace Api.TorMarket.Domain.Entities;

public class OrderStatus
{
    public int Id { get; set; }
    public string? Status { get; set; }

    public virtual IReadOnlyCollection<Order> Orders { get; set; } = null!;
}
