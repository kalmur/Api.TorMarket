 namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public record CreateListingFailure
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