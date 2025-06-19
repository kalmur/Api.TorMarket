using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public class GetListingsByNameHandler : IQueryHandler<GetListingsByNameQuery, ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>>
{
    private readonly IValidator<GetListingsByNameQuery, GetListingsByNameFailure> _validator;
    private readonly IListingRepository _listingRepository;

    public GetListingsByNameHandler(
        IValidator<GetListingsByNameQuery, GetListingsByNameFailure> validator,
        IListingRepository listingRepository
    )
    {
        _validator = validator;
        _listingRepository = listingRepository;
    }

    public async Task<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>> HandleAsync(
        GetListingsByNameQuery query,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await _validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return (
            await _listingRepository.GetByNameAsync(
                query.Name,
                cancellationToken
            )
        ).ToList();
    }
}