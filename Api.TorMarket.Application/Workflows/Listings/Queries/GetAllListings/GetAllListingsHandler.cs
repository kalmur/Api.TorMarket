using System.Collections.Immutable;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Listings.Queries.GetAllListings;

public class GetAllListingsHandler(
    IListingRepository repository
) : IRequestHandler<GetAllListingsQuery, ImmutableArray<Listing>>
{
    public async Task<ImmutableArray<Listing>> Handle(GetAllListingsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}