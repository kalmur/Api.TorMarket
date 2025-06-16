using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed class GetAllListingsHandler(
    IListingRepository repository
) : IQueryHandler<GetAllListingsQuery, IEnumerable<ListingWithDetails>>
{
    public async Task<IEnumerable<ListingWithDetails>> HandleAsync(
        GetAllListingsQuery query, 
        CancellationToken cancellationToken
    ) => await repository.GetAllAsync(cancellationToken);
}