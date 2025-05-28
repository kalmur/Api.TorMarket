namespace Api.TorMarket.Domain.Models;

public record OrderStatus
{
    public const int Status_MaxLength = 50;

    public required int OrderStatusId { get; init; }
    public required string Status { get; init; }
}
