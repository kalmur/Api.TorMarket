using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public class GetListingsByNameHandler(
    IValidator<GetListingsByNameQuery, GetListingsByNameFailure> validator,
    IListingRepository listingRepository
) : IRequestHandler<GetListingsByNameQuery, ResultOrError<IEnumerable<ListingWithCategory>, GetListingsByNameFailure>>
{
    public async Task<ResultOrError<IEnumerable<ListingWithCategory>, GetListingsByNameFailure>> Handle(
        GetListingsByNameQuery query,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await listingRepository.GetByNameAsync(
            query.Name,
            cancellationToken
        );
    }
}