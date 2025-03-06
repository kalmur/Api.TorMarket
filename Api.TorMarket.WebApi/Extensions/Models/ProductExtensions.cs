using Api.TorMarket.Application.Workflows.Product.Queries.GetCategoryByName;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.Extensions.Results;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ProductExtensions
{
    public static ProductDto ToCreateProductResponseDto(
        this Product product
    ) => new ProductDto
    {
        ProductId = product.ProductId,
        CategoryId = product.CategoryId,
        Name = product.Name,
        Price = product.Price,
        Description = product.Description,
        AvailableFrom = product.AvailableFrom
    };

    public static GetCategoryByNameQuery ToQuery(
        this string name
    ) => new()
    {
        Name = name
    };
}
