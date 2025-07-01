using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;

public sealed class GetListingByIdHandler : IQueryHandler<GetListingByIdQuery, ListingWithDetails>
{
    private readonly IListingRepository _repository;

    public GetListingByIdHandler(IListingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListingWithDetails> HandleAsync(
        GetListingByIdQuery request,
        CancellationToken cancellationToken
    ) => await _repository.GetByIdAsync(
        request.Id,
        cancellationToken
    );
}
