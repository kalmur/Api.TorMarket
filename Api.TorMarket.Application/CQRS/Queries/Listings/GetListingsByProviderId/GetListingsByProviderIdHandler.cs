using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

internal sealed class GetListingsByProviderIdHandler(
    IValidator<GetListingsByProviderIdQuery, GetListingsByProviderIdFailure> validator,
    IListingRepository listingRepository
) : IRequestHandler<GetListingsByProviderIdQuery, ResultOrError<IEnumerable<ListingWithCategory>, GetListingsByProviderIdFailure>>
{
    public async Task<ResultOrError<IEnumerable<ListingWithCategory>, GetListingsByProviderIdFailure>> Handle(
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

        return await listingRepository.GetByProviderIdAsync(
            query.ProviderId, 
            cancellationToken
        );
    }
}
