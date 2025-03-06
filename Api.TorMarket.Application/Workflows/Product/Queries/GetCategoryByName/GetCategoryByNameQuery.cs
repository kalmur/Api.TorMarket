using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Product.Queries.GetCategoryByName;

public class GetCategoryByNameQuery : IRequest<ResultOrError<ProductCategory, GetCategoryByNameFailure>>
{
    public required string Name { get; init; }
}