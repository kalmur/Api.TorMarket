namespace Api.TorMarket.Domain.Models;

public record ListingWithUserAndCategory : Listing
{
    public User? User { get; set; }
    public ListingCategory? Category { get; set; }
}
