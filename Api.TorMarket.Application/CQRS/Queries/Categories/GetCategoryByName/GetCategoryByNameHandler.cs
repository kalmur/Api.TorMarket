using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;

public sealed class GetCategoryByNameHandler : IQueryHandler<GetCategoryByNameQuery, ResultOrError<Category, GetCategoryByNameFailure>>
{
    private readonly IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure> _validator;
    private readonly ICategoryRepository _productCategoryRepository;

    public GetCategoryByNameHandler(
        IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure> validator,
        ICategoryRepository productCategoryRepository
    )
    {
        _validator = validator;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ResultOrError<Category, GetCategoryByNameFailure>> HandleAsync(
        GetCategoryByNameQuery query,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await _validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return (
            await _productCategoryRepository.GetByNameAsync(
                query.Name,
                cancellationToken
            )
        )!;
    }
}
