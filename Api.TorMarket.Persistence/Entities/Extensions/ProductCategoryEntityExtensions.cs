using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ProductCategoryEntityExtensions
{
    public static ListingCategory? ToModel(
        this ListingCategoryEntity entity
    ) => new()
    {
        CategoryId = entity.ListingCategoryId,
        Name = entity.Name ?? string.Empty
    };
}
