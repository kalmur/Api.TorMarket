using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;

internal sealed class GetListingsByCategoryNameHandler(
    IListingRepository repository
) : IRequestHandler<GetListingsByCategoryNameQuery, IEnumerable<ListingWithCategory?>>
{
    public async Task<IEnumerable<ListingWithCategory?>> Handle(
        GetListingsByCategoryNameQuery request,
        CancellationToken cancellationToken
    ) =>
        await repository.GetByCategoryNameAsync(
            request.CategoryName,
            cancellationToken
        );
}
