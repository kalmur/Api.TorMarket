namespace Api.TorMarket.Domain.Models;

public class ListingReview
{
    public int ListingReviewId { get; set; }
    public int UserId { get; set; }
    public int ListingId { get; set; }
    public int Value { get; set; }
    public string Comment { get; set; } = string.Empty;
}
