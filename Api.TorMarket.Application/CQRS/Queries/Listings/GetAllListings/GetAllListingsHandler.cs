using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

internal sealed class GetAllListingsHandler(
    IListingRepository repository
) : IRequestHandler<GetAllListingsQuery, IEnumerable<ListingWithDetails>>
{
    public async Task<IEnumerable<ListingWithDetails>> Handle(
        GetAllListingsQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetAllInRandomOrder(cancellationToken);
}