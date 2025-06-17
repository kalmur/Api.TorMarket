using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;

public sealed class GetListingByIdHandler(
    IListingRepository repository
) : IQueryHandler<GetListingByIdQuery, ListingWithDetails>
{
    public async Task<ListingWithDetails> HandleAsync(
        GetListingByIdQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetByIdAsync(
        request.Id, 
        cancellationToken
    );
}
