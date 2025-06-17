using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public class GetListingsByNameHandler(
    IValidator<GetListingsByNameQuery, GetListingsByNameFailure> validator,
    IListingRepository listingRepository
) : IQueryHandler<GetListingsByNameQuery, ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>>
{
    public async Task<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>> HandleAsync(
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

        return (
            await listingRepository.GetByNameAsync(
                query.Name,
                cancellationToken
            )
        ).ToList();
    }
}