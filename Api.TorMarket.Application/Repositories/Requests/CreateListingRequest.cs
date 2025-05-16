namespace Api.TorMarket.Application.Repositories.Requests;

public record CreateListingRequest
{
    public required int UserId { get; set; }
    public required string Name { get; set; }
    public required int CategoryId { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public IEnumerable<string>? ImageUrls { get; set; }
}