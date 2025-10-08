using Api.TorMarket.Application.Abstractions.Azure;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public class GetListingsByNameHandler : IQueryHandler<GetListingsByNameQuery, ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>>
{
    private readonly IValidator<GetListingsByNameQuery, GetListingsByNameFailure> _validator;
    private readonly IListingRepository _listingRepository;
    private readonly ISearchService _searchService;

    public GetListingsByNameHandler(
        IValidator<GetListingsByNameQuery, GetListingsByNameFailure> validator,
        IListingRepository listingRepository,
        ISearchService searchService
    )
    {
        _validator = validator;
        _listingRepository = listingRepository;
        _searchService = searchService;
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

        // expandedQuery = await _openAiService.ExpandQueryAsync(query.Name, cancellationToken);

        var azureSearchResponse = await _searchService.SearchAsync(
            query.Name,
            cancellationToken
        );

        // Add failure if search fails

        var listingIds = azureSearchResponse.Select(searchResult => searchResult.ListingId);

        return (
            await _listingRepository.GetByIdsAsync(
                listingIds,
                cancellationToken
            )
        ).ToList();
    }
}