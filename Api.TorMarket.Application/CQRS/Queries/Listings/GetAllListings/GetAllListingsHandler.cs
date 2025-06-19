using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed class GetAllListingsHandler : IQueryHandler<GetAllListingsQuery, PaginatedResult<ListingWithDetails>>
{
    private readonly IListingRepository _repository;

    public GetAllListingsHandler(IListingRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedResult<ListingWithDetails>> HandleAsync(
        GetAllListingsQuery request,
        CancellationToken cancellationToken
    ) => await _repository.GetAllPaginatedAsync(
        request.PaginatedRequest,
        cancellationToken
    );
}