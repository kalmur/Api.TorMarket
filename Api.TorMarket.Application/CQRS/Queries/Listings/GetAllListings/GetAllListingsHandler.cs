using System.Collections.Immutable;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

internal class GetAllListingsHandler(
    IListingRepository repository
) : IRequestHandler<GetAllListingsQuery, ImmutableArray<ListingWithUserAndCategory>>
{
    public async Task<ImmutableArray<ListingWithUserAndCategory>> Handle(
        GetAllListingsQuery request, 
        CancellationToken cancellationToken
    )
    {
        return await repository.GetAllInRandomOrder(cancellationToken);
    }
}