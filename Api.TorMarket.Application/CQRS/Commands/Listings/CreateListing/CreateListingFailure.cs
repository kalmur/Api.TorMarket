namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed record CreateListingFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }

    public enum ErrorType
    {
        InvalidName,
        InvalidCategoryId,
        InvalidPrice,
        UserDoesNotExist
    }
}