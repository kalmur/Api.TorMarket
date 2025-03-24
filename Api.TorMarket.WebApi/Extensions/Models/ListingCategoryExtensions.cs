using Api.TorMarket.Application.Workflows.Product.Queries.GetCategoryByName;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.Extensions.Results;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ListingCategoryExtensions
{
    public static ListingCategoryDto ToResponseDto(
       this ListingCategory product
   ) => new()
   {
       ProductCategoryId = product.CategoryId,
       Name = product.Name
   };

    public static GetCategoryByNameQuery ToQuery(
        this string name
    ) => new()
    {
        Name = name
    };
}
