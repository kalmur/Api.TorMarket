using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingCategoryEntityExtensions
{
    public static Category? ToModel(
        this CategoryEntity entity
    ) => new()
    {
        CategoryId = entity.CategoryId,
        Name = entity.Name
    };
}
