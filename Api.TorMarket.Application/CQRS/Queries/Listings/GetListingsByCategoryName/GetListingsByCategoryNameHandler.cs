using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;

public sealed class GetListingsByCategoryNameHandler : IQueryHandler<GetListingsByCategoryNameQuery, IEnumerable<ListingWithDetails?>>
{
    private readonly IListingRepository _repository;

    public GetListingsByCategoryNameHandler(IListingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ListingWithDetails?>> HandleAsync(
        GetListingsByCategoryNameQuery request,
        CancellationToken cancellationToken
    ) =>
        await _repository.GetByCategoryNameAsync(
            request.CategoryName,
            cancellationToken
        );
}
