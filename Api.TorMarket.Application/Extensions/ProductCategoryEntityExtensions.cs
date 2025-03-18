using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class ProductCategoryEntityExtensions
{
    public static ListingCategory? ToModel(
        this ListingCategoryEntity entity
    ) => new()
    {
        CategoryId = entity.ListingCategoryId,
        Name = entity.Name ?? string.Empty
    };
}
