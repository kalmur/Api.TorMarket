namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForUser;

public class GetListingsForUserValidator : IValidator<GetListingsForUserQuery, GetListingsForUserFailure>
{
    public Task<GetListingsForUserFailure?> ValidateAsync(GetListingsForUserQuery command, CancellationToken cancellationToken)
    {
        return null;
    }
}
