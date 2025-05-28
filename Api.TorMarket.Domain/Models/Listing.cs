namespace Api.TorMarket.Domain.Models;

public record Listing
{
    public const int Name_MaxLength = 100;
    public const int Description_MaxLength = 500;

    public int ListingId { get; init; }
    public int UserId { get; init; }
    public int CategoryId { get; init; }
    public string? Name { get; set; }
    public decimal Price { get; init; }
    public string? Description { get; init; }
    public List<string>? BlobUrls { get; init; }
}
