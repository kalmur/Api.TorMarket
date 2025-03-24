using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using ListingCategoryEntity = Api.TorMarket.Persistence.Entities.ListingCategoryEntity;
using OrderStatusEntity = Api.TorMarket.Persistence.Entities.OrderStatusEntity;

namespace Api.TorMarket.Persistence.Context;

public static class DataSeed
{
    public static void SeedData(ModelBuilder builder)
    {
        SeedOrderStatuses(builder);
        SeedProductCategories(builder);
    }

    private static void SeedOrderStatuses(ModelBuilder builder)
    {
        static OrderStatusEntity CreateOrderStatus(
            int id,
            string status
        ) => new()
        {
            OrderStatusId = id,
            Status = status
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

    private static void SeedProductCategories(ModelBuilder builder)
    {
        static ListingCategoryEntity CreateProductCategories(
            int id,
            string name
        ) => new()
        {
            ListingCategoryId = id,
            Name = name
        };

        IImmutableList<ListingCategoryEntity> productCategories = ImmutableList.Create(
            CreateProductCategories(1, "Electronics"),
            CreateProductCategories(2, "Games"),
            CreateProductCategories(3, "Toys"),
            CreateProductCategories(4, "Clothing"),
            CreateProductCategories(5, "Vehicles"),
            CreateProductCategories(6, "Pets"),
            CreateProductCategories(7, "Other")
        );

        builder.Entity<ListingCategoryEntity>().HasData(productCategories);
    }
}
