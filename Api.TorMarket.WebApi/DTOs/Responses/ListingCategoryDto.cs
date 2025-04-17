namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ListingCategoryDto
{
    public required int CategoryId { get; init; }
    public required string Name { get; init; }
}
