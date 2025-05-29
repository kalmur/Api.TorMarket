using System.Collections.Immutable;
using Api.TorMarket.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Context;

internal static class DataSeed
{
    public static void SeedData(ModelBuilder builder)
    {
        SeedRoles(builder);
        SeedCategories(builder);
        SeedOrderStatuses(builder);
        SeedAdminUser(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        IImmutableList<RoleEntity> roles = ImmutableList.Create(
            CreateRoles(1, "Admin"),
            CreateRoles(2, "User")
        );

        builder.Entity<RoleEntity>().HasData(roles);
    }

    private static void SeedOrderStatuses(ModelBuilder builder)
    {
        IImmutableList<OrderStatusEntity> orderStatuses = ImmutableList.Create(
            CreateOrderStatus(1, "Pending"),
            CreateOrderStatus(2, "Processing"),
            CreateOrderStatus(3, "Shipped"),
            CreateOrderStatus(4, "Delivered"),
            CreateOrderStatus(5, "Cancelled")
        );

        builder.Entity<OrderStatusEntity>().HasData(orderStatuses);
    }

    private static void SeedCategories(ModelBuilder builder)
    {
        IImmutableList<CategoryEntity> categories = ImmutableList.Create(
            CreateListingCategory(1, "Electronics"),
            CreateListingCategory(2, "Games"),
            CreateListingCategory(3, "Toys"),
            CreateListingCategory(4, "Clothing"),
            CreateListingCategory(5, "Vehicles"),
            CreateListingCategory(6, "Pets"),
            CreateListingCategory(7, "Other")
        );

        builder.Entity<CategoryEntity>().HasData(categories);
    }

    private static void SeedAdminUser(ModelBuilder builder)
    {
        var adminUser = new UserEntity
        {
            UserId = 1,
            RoleId = 1,
            ProviderId = "auth0|6821c63e7bd4b1c29438d9e3"
        };

        builder.Entity<UserEntity>().HasData(adminUser);
    }

    // Helper method

    private static RoleEntity CreateRoles(
        int roleId,
        string roleName
    ) => new()
    {
        RoleId = roleId,
        Name = roleName
    };

    private static OrderStatusEntity CreateOrderStatus(
        int orderStatusId,
        string statusName
    ) => new()
    {
        OrderStatusId = orderStatusId,
        Status = statusName
    };

    private static CategoryEntity CreateListingCategory(
        int listingCategoryId,
        string categoryName
    ) => new()
    {
        CategoryId = listingCategoryId,
        Name = categoryName
    };
}
