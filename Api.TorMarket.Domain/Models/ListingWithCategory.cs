namespace Api.TorMarket.Domain.Models;

public class ListingWithCategory : Listing
{
    public ListingCategory? Category { get; set; }
}
