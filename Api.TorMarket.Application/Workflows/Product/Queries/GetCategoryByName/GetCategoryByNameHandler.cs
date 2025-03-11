using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Product.Queries.GetCategoryByName;

public class GetCategoryByNameHandler(
    IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure> validator,
    IProductCategoryRepository productCategoryRepository
) : IRequestHandler<GetCategoryByNameQuery, ResultOrError<ProductCategory ,GetCategoryByNameFailure>>
{
    public async Task<ResultOrError<ProductCategory, GetCategoryByNameFailure>> Handle(
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
