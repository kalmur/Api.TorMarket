using Api.TorMarket.Application.Repositories;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

internal sealed class GetAllListingsHandler(
    IListingRepository repository
) : IRequestHandler<GetAllListingsQuery, PaginatedResult<ListingWithDetails>>
{
    public async Task<PaginatedResult<ListingWithDetails>> Handle(
        GetAllListingsQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetAllPaginatedAsync(
        request.PaginatedRequest,
        cancellationToken
    );
}