using System.Collections.Immutable;
using Api.TorMarket.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Context;

internal static class DataSeed
{
    public static void SeedData(ModelBuilder builder)
    {
        SeedOrderStatuses(builder);
        SeedListingCategories(builder);
        SeedAdminUser(builder);
    }

    private static void SeedOrderStatuses(ModelBuilder builder)
    {
        static OrderStatusEntity CreateOrderStatus(
            int orderStatusId,
            string statusName
        ) => new()
        {
            OrderStatusId = orderStatusId,
            Status = statusName
        };

        IImmutableList<OrderStatusEntity> orderStatuses = ImmutableList.Create(
            CreateOrderStatus(1, "Pending"),
            CreateOrderStatus(2, "Processing"),
            CreateOrderStatus(3, "Shipped"),
            CreateOrderStatus(4, "Delivered"),
            CreateOrderStatus(5, "Cancelled")
        );

        builder.Entity<OrderStatusEntity>().HasData(orderStatuses);
    }

    private static void SeedListingCategories(ModelBuilder builder)
    {
        static ListingCategoryEntity CreateListingCategory(
            int listingCategoryId,
            string categoryName
        ) => new()
        {
            ListingCategoryId = listingCategoryId,
            Name = categoryName
        };

        IImmutableList<ListingCategoryEntity> listingCategories = ImmutableList.Create(
            CreateListingCategory(1, "Electronics"),
            CreateListingCategory(2, "Games"),
            CreateListingCategory(3, "Toys"),
            CreateListingCategory(4, "Clothing"),
            CreateListingCategory(5, "Vehicles"),
            CreateListingCategory(6, "Pets"),
            CreateListingCategory(7, "Other")
        );

        builder.Entity<ListingCategoryEntity>().HasData(listingCategories);
    }
    private static void SeedAdminUser(ModelBuilder builder)
    {
        var adminUser = new UserEntity
        {
            UserId = 1,
            ProviderId = "auth0|67b6687fb71ed3cae5848607"
        };

        builder.Entity<UserEntity>().HasData(adminUser);
    }
}
