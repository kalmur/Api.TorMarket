using Api.TorMarket.Application.Repositories.Interfaces;
using static Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName.GetListingsByNameFailure;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public class GetListingByNameValidator(
    IListingRepository listingRepository
) : IValidator<GetListingsByNameQuery, GetListingsByNameFailure>
{
    public async Task<GetListingsByNameFailure?> ValidateAsync(
        GetListingsByNameQuery query, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrWhiteSpace(query.Name))
            errors.Add(ErrorType.InvalidName);

        if (await ListingsNotFound(query.Name, cancellationToken))
            errors.Add(ErrorType.NotFound);

        if (errors.Count > 0)
        {
            return new GetListingsByNameFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> ListingsNotFound(
        string name,
        CancellationToken cancellationToken
    ) =>
        (
            await listingRepository.GetByNameAsync(
                name, 
                cancellationToken
            )
        ).Count == 0;
}
