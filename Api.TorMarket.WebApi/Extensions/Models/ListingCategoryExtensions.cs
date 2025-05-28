using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ListingCategoryExtensions
{
    public static ListingCategoryDto ToResponseDto(
       this Category product
   ) => new()
   {
       CategoryId = product.CategoryId,
       Name = product.Name
   };

    public static IEnumerable<ListingCategoryDto> ToResponseDto(
        this IEnumerable<Category> listings
    ) => listings.Select(ToResponseDto);
}
