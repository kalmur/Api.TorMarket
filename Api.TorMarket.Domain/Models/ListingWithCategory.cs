namespace Api.TorMarket.Domain.Models;

public record ListingWithCategory : Listing
{
    public ListingCategory? Category { get; set; }
}
