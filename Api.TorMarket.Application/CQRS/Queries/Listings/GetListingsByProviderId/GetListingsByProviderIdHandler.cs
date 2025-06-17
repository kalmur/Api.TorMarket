using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

public class GetListingsByProviderIdHandler(
    IValidator<GetListingsByProviderIdQuery, GetListingsByProviderIdFailure> validator,
    IListingRepository listingRepository
) : IQueryHandler<GetListingsByProviderIdQuery, ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByProviderIdFailure>>
{
    public async Task<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByProviderIdFailure>> HandleAsync(
        GetListingsByProviderIdQuery query, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return (
            await listingRepository.GetByProviderIdAsync(
                query.ProviderId,
                cancellationToken
            )
        ).ToList();
    }
}
