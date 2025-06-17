using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;

public sealed class GetCategoryByNameHandler(
    IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure> validator,
    ICategoryRepository productCategoryRepository
) : IQueryHandler<GetCategoryByNameQuery, ResultOrError<Category, GetCategoryByNameFailure>>
{
    public async Task<ResultOrError<Category, GetCategoryByNameFailure>> HandleAsync(
        GetCategoryByNameQuery query, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return (
            await productCategoryRepository.GetByNameAsync(
                query.Name,
                cancellationToken
            )
        )!;
    }
}
