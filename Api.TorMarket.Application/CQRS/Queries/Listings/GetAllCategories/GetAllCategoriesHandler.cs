using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllCategories;

internal class GetAllCategoriesHandler(IListingCategoryRepository repository) : IRequestHandler<GetAllCategoriesRequest, IEnumerable<ListingCategory>>
{
    public async Task<IEnumerable<ListingCategory>> Handle(
        GetAllCategoriesRequest request, 
        CancellationToken cancellationToken
    )
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}
