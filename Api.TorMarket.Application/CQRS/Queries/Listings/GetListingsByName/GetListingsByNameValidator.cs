using Api.TorMarket.Application.Repositories.Interfaces;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListing;

public class GetListingByNameValidator(
    IListingRepository listingRepository
) : IValidator<GetListingsByNameQuery, GetListingsByNameFailure>
{
    public async Task<GetListingsByNameFailure?> ValidateAsync(
        GetListingsByNameQuery query, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<GetListingsByNameFailure.ErrorType>();

        if (string.IsNullOrWhiteSpace(query.Name))
            errors.Add(GetListingsByNameFailure.ErrorType.InvalidName);

        // Add notFound
        
        if (errors.Count > 0)
        {
            return new GetListingsByNameFailure
            {
                Errors = errors
            };
        }

        return null;
    }
}
