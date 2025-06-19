using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

public class GetListingsByProviderIdHandler : IQueryHandler<GetListingsByProviderIdQuery, ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByProviderIdFailure>>
{
    private readonly IValidator<GetListingsByProviderIdQuery, GetListingsByProviderIdFailure> _validator;
    private readonly IListingRepository _listingRepository;

    public GetListingsByProviderIdHandler(
        IValidator<GetListingsByProviderIdQuery, GetListingsByProviderIdFailure> validator,
        IListingRepository listingRepository
    )
    {
        _validator = validator;
        _listingRepository = listingRepository;
    }

    public async Task<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByProviderIdFailure>> HandleAsync(
        GetListingsByProviderIdQuery query,
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
            await _listingRepository.GetByProviderIdAsync(
                query.ProviderId,
                cancellationToken
            )
        ).ToList();
    }
}
