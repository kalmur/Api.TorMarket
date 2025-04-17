namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

public sealed record GetListingsByProviderIdFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }

    public enum ErrorType
    {
        UserNotFound
    }
}
