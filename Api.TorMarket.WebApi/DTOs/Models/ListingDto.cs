namespace Api.TorMarket.WebApi.DTOs.Models;

public record ListingDto
{
    public required int ListingId { get; init; }
    public required int UserId { get; init; }
    public required int CategoryId { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required string Description { get; init; }
    public required DateTimeOffset AvailableFrom { get; init; }
}