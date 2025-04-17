using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;

public class GetListingByIdHandler(
    IListingRepository repository
) : IRequestHandler<GetListingByIdQuery, ListingWithCategory>
{
    public async Task<ListingWithCategory> Handle(
        GetListingByIdQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetByIdAsync(
        request.Id, 
        cancellationToken
    );
}
