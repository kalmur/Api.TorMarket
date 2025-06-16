using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.Tests.ModelGenerators;

internal static class ListingGenerator
{
    internal static Listing GenerateListing(
        int listingId = 1,
        int userId = 1
    ) => new()
    {
        ListingId = listingId,
        UserId = userId,
        Title = "Test",
        Description = "Test",
        Price = 50.00m
    };

    internal static ListingWithDetails GenerateListingWithUserAndCategory(
        int listingId = 1,
        int userId = 1,
        int categoryId = 1
    ) => new()
    {
        ListingId = listingId,
        UserId = userId,
        CategoryId = categoryId,
        Title = "Test",
        Description = "Test",
        Price = 50.00m,
        Category = ListingCategoryGenerator.GenerateListingCategory(
            categoryId
        ),
        User = UserGenerator.GenerateUser(
            userId
        ),
        // TODO - Create method
        ListingBlobs = new List<ListingBlob>()
    };
}
