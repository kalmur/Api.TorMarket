using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;

internal sealed class GetListingByIdHandler(
    IListingRepository repository
) : IRequestHandler<GetListingByIdQuery, ListingWithDetails>
{
    public async Task<ListingWithDetails> Handle(
        GetListingByIdQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetByIdAsync(
        request.Id, 
        cancellationToken
    );
}
