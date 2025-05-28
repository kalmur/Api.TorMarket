namespace Api.TorMarket.Domain.Models;

public record ListingCategory
{
    public required int CategoryId { get; init; }
    public required string Name { get; init; }
}
