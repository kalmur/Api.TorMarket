namespace Api.TorMarket.Domain.Models;

public class ListingWithUserAndCategory : Listing
{
    public User? User { get; set; }
    public ListingCategory? Category { get; set; }
}
