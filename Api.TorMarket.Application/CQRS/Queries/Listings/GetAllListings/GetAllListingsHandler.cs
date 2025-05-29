using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

internal sealed class GetAllListingsHandler(
    IListingRepository repository
) : IRequestHandler<GetAllListingsQuery, IEnumerable<ListingWithUserAndCategory>>
{
    public async Task<IEnumerable<ListingWithUserAndCategory>> Handle(
        GetAllListingsQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetAllInRandomOrder(cancellationToken);
}