namespace Api.TorMarket.Domain.Models;

public record ListingReview
{
    public const int Comment_MaxLength = 250;

    public int ListingReviewId { get; init; }
    public required int UserId { get; init; }
    public required int ListingId { get; init; }
    public required int Value { get; init; }
    public string Comment { get; init; } = string.Empty;
}
