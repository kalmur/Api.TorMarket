using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed class GetAllListingsHandler(
    IListingRepository repository
) : IQueryHandler<GetAllListingsQuery, PaginatedResult<ListingWithDetails>>
{
    public async Task<PaginatedResult<ListingWithDetails>> HandleAsync(
        GetAllListingsQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetAllPaginatedAsync(
        request.PaginatedRequest,
        cancellationToken
    );
}