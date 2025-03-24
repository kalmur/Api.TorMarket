namespace Api.TorMarket.Application.Workflows.Listings.Commands.CreateListing;

public record CreateListingFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }
}

public enum ErrorType
{
    InvalidName,
    InvalidCategoryId,
    InvalidPrice,
    UserDoesNotExist
}