using Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingByCategoryName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
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
    
    public static GetListingsByNameQuery ToGetByNameQuery(
        this string name
    ) => new()
    {
        Name = name
    };

    public static GetListingsByCategoryNameQuery ToListingsForCategory(
        this string name
    ) => new()
    {
        CategoryName = name
    };
}
