using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Tests.ModelGenerators;

internal static class ListingCategoryGenerator
{
    internal static ListingCategory GenerateListingCategory(
        int categoryId = 1
    ) => new()
    {
        CategoryId = categoryId,
        Name = "Category"
    };
}
