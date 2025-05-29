namespace Api.TorMarket.Domain.Models.ViewModels;

public record ListingWithReviewAndCategory : ListingReview
{
    public Listing? Listing { get; set; }
    public Category? Category { get; set; }
}
