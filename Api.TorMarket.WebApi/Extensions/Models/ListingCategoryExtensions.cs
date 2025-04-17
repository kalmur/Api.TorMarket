using Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ListingCategoryExtensions
{
    public static ListingCategoryDto ToResponseDto(
       this ListingCategory product
   ) => new()
   {
       CategoryId = product.CategoryId,
       Name = product.Name
   };

    public static GetCategoryByNameQuery ToQuery(
        this string name
    ) => new(name);
}
