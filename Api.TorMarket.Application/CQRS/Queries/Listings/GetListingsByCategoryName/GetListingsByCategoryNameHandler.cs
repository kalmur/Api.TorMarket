using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingByCategoryName;

public class GetListingsByCategoryNameHandler(IListingRepository repository) : IRequestHandler<GetListingsByCategoryNameQuery, IEnumerable<ListingWithCategory?>>
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
