namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

public record CreateListingReviewFailure
{
    public required IEnumerable<ErrorType> Errors { get; init; }

    public enum ErrorType
    {
        ListingNotFound,
        UserNotFound,
        ReviewAlreadyExists,
        InvalidValue,
        InvalidComment
    }
}
