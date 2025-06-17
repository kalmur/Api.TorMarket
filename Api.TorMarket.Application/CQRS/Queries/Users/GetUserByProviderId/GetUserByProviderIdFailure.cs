namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed record GetUserByProviderIdFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }

    public enum ErrorType
    {
        UserDoesNotExist
    }
}
