using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;

internal sealed class GetCategoryByNameHandler(
    IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure> validator,
    ICategoryRepository productCategoryRepository
) : IRequestHandler<GetCategoryByNameQuery, ResultOrError<Category, GetCategoryByNameFailure>>
{
    public async Task<ResultOrError<Category, GetCategoryByNameFailure>> Handle(
        GetCategoryByNameQuery request,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            request,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return (
            await productCategoryRepository.GetByNameAsync(
                request.Name,
                cancellationToken
            )
        )!;
    }
}
