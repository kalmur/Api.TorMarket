using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;

public sealed class GetListingsByCategoryNameHandler(
    IListingRepository repository
) : IQueryHandler<GetListingsByCategoryNameQuery, IEnumerable<ListingWithDetails?>>
{
    public async Task<IEnumerable<ListingWithDetails?>> HandleAsync(
        GetListingsByCategoryNameQuery request,
        CancellationToken cancellationToken
    ) =>
        await repository.GetByCategoryNameAsync(
            request.CategoryName,
            cancellationToken
        );
}
