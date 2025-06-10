using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;

public sealed class GetAllCategoriesHandler(
    ICategoryRepository repository
) : IQueryHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    public async Task<IEnumerable<Category>> HandleAsync(
        GetAllCategoriesQuery query,
        CancellationToken cancellationToken
    ) => await repository.GetAllAsync(cancellationToken);
}