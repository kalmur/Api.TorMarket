namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ListingDto
{
    public required int ListingId { get; set; }
    public required int CategoryId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset AvailableFrom { get; set; }
}