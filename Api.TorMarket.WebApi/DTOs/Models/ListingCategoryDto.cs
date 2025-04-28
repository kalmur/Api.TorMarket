namespace Api.TorMarket.WebApi.DTOs.Models;

public record ListingCategoryDto
{
    public required int CategoryId { get; init; }
    public required string Name { get; init; }
}
