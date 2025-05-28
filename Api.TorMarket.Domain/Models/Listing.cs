namespace Api.TorMarket.Domain.Models;

public record Listing
{
    // Rename to title?!
    public const int ListingNameMaxLength = 100;

    public int ListingId { get; init; }
    public int UserId { get; init; }
    public int CategoryId { get; init; }
    public string? Name { get; set; }
    public decimal Price { get; init; }
    public string? Description { get; init; }
    public List<string>? BlobUrls { get; init; }
}
