namespace Api.TorMarket.Domain.Models;

public class ListingWithReviewAndCategory : ListingReview
{
    public Listing? Listing { get; set; }
    public ListingCategory? Category { get; set; }
}
