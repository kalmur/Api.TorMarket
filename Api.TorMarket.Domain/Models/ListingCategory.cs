namespace Api.TorMarket.Domain.Models;

public record ListingCategory
{
    public const int Name_MaxLength = 15;

    public required int CategoryId { get; init; }
    public required string Name { get; init; }
}
