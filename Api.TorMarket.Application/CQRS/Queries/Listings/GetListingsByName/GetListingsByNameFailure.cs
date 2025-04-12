namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListing;

public class GetListingsByNameFailure
{
    public ErrorType Error { get; set; }

    public enum ErrorType
    {
        NotFound,
        InvalidInput,
        Unauthorized,
        Unknown
    }
}
