namespace Api.TorMarket.Domain.Models;

public record ProductCategory
{
    public required int ProductCategoryId { get; init; }
    public required string Name { get; init; }
}
