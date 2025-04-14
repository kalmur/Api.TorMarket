namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForUser;

public class GetListingsForUserFailure
{
    public ErrorType Error { get; set; }

    public enum ErrorType
    {
        UserNotFound,
        NoListings
    }
}
