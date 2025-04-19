namespace Api.TorMarket.Application.Repositories.Requests;

public record CreateListingReviewRequest
{
    public required int UserId { get; init; }

    public required int ListingId { get; init; }

    public required int Value { get; init; }

    public required string Comment { get; init; }
}