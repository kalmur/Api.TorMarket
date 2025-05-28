namespace Api.TorMarket.Domain.Models;

public record ListingWithReviewAndCategory : ListingReview
{
    public Listing? Listing { get; set; }
    public ListingCategory? Category { get; set; }
}
