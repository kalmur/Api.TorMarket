using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;

internal sealed class GetAllCategoriesHandler(
    ICategoryRepository repository
) : IRequestHandler<GetAllCategoriesRequest, IEnumerable<Category>>
{
    public async Task<IEnumerable<Category>> Handle(
        GetAllCategoriesRequest request,
        CancellationToken cancellationToken
    )
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}
