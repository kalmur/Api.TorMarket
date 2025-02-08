using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.SeedData;

public class OrderStatusSeedData
{
    public static readonly List<OrderStatus> OrderStatuses =
    [
        new OrderStatus { Id = 1, Status = "Pending" },
        new OrderStatus { Id = 2, Status = "Processing" },
        new OrderStatus { Id = 3, Status = "Shipped" },
        new OrderStatus { Id = 4, Status = "Delivered" },
        new OrderStatus { Id = 5, Status = "Cancelled" },
    ];
}
