namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListing;

public sealed record GetListingsByNameFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }

    public enum ErrorType
    {
        InvalidName,
        NotFound
    }
}
