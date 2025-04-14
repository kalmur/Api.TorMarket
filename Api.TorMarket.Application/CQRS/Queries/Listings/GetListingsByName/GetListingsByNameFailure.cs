namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public sealed record GetListingsByNameFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }

    public enum ErrorType
    {
        InvalidName,
        NotFound
    }
}
