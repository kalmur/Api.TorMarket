namespace Api.TorMarket.Domain.Models;

public record ListingWithCategory : Listing
{
    public Category? Category { get; set; }
}
