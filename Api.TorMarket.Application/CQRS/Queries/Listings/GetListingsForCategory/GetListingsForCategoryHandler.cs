using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForCategory;

public class GetListingsForCategoryHandler(IListingRepository repository) : IRequestHandler<GetListingsForCategoryQuery, IEnumerable<ListingWithCategory?>>
{
    public async Task<IEnumerable<ListingWithCategory?>> Handle(
        GetListingsForCategoryQuery request,
        CancellationToken cancellationToken
    ) =>
        await repository.GetListingsForCategoryAsync(
            request.CategoryName,
            cancellationToken
        );
}
