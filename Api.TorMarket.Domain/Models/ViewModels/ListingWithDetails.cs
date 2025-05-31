namespace Api.TorMarket.Domain.Models.ViewModels;

public record ListingWithDetails : Listing
{
    public User? User { get; set; }
    public Category? Category { get; set; }
    public List<ListingBlob>? ListingBlobs { get; set; }
}
