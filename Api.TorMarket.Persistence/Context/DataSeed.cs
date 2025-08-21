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
        SeedCurrencies(builder);
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

    private static void SeedCategories(ModelBuilder builder)
    {
        IImmutableList<CategoryEntity> categories = ImmutableList.Create(
            CreateCategory(1, "Electronics"),
            CreateCategory(2, "Games"),
            CreateCategory(3, "Toys"),
            CreateCategory(4, "Clothing"),
            CreateCategory(5, "Vehicles"),
            CreateCategory(6, "Pets"),
            CreateCategory(7, "Other")
        );

        builder.Entity<CategoryEntity>().HasData(categories);
    }

    private static void SeedCurrencies(ModelBuilder builder)
    {
        IImmutableList<CurrencyEntity> currencies = ImmutableList.Create(
            CreateCurrency(1, "USD", "$", "United States Dollar"),
            CreateCurrency(2, "EUR", "€", "Euro"),
            CreateCurrency(3, "JPY", "¥", "Japanese Yen"),
            CreateCurrency(4, "GBP", "£", "British Pound Sterling"),
            CreateCurrency(5, "AUD", "$", "Australian Dollar"),
            CreateCurrency(6, "BTC", "₿", "Bitcoin"),
            CreateCurrency(7, "ETH", "Ξ", "Ethereum"),
            CreateCurrency(8, "SOL", "◎", "Solana"),
            CreateCurrency(9, "XRP", "X", "Ripple"),
            CreateCurrency(10, "ADA", "₳", "Cardano")
        );

        builder.Entity<CurrencyEntity>().HasData(currencies);
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

    private static void SeedAdminUser(ModelBuilder builder)
    {
        var adminUser = new UserEntity
        {
            UserId = 1,
            RoleId = 1,
            ProviderId = "auth0|68a5d34d77f7ffc81f90691f"
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

    private static CategoryEntity CreateCategory(
        int listingCategoryId,
        string categoryName
    ) => new()
    {
        CategoryId = listingCategoryId,
        Name = categoryName
    };

    private static CurrencyEntity CreateCurrency(
       int currencyId,
       string code,
       string symbol,
       string name
   ) => new()
   {
       CurrencyId = currencyId,
       Code = code,
       Symbol = symbol,
       Name = name
   };

    private static OrderStatusEntity CreateOrderStatus(
        int orderStatusId,
        string statusName
    ) => new()
    {
        OrderStatusId = orderStatusId,
        Status = statusName
    };
}
