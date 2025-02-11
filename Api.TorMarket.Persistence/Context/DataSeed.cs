using System.Collections.Immutable;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Context;

public static class DataSeed
{
    internal static void SeedData(ModelBuilder builder)
    {
        SeedOrderStatuses(builder);
        SeedProductCategories(builder);
    }

    private static void SeedOrderStatuses(ModelBuilder builder)
    {
        static OrderStatus CreateOrderStatus(
            int id,
            string status
        ) => new()
        {
            Id = id,
            Status = status
        };

        IImmutableList<OrderStatus> orderStatuses = ImmutableList.Create(
            CreateOrderStatus(1, "Pending"),
            CreateOrderStatus(2, "Processing"),
            CreateOrderStatus(3, "Shipped"),
            CreateOrderStatus(4, "Delivered"),
            CreateOrderStatus(5, "Cancelled")
        );

        builder.Entity<OrderStatus>().HasData(orderStatuses);
    }

    private static void SeedProductCategories(ModelBuilder builder)
    {
        static ProductCategory CreateProductCategories(
            int id,
            string name
        ) => new()
        {
            Id = id,
            Name = name
        };

        IImmutableList<ProductCategory> productCategories = ImmutableList.Create(
            CreateProductCategories(1, "Electronics"),
            CreateProductCategories(2, "Games"),
            CreateProductCategories(3, "Toys"),
            CreateProductCategories(4, "Clothing"),
            CreateProductCategories(5, "Vehicles"),
            CreateProductCategories(6, "Pets"),
            CreateProductCategories(7, "Other")
        );

        builder.Entity<ProductCategory>().HasData(productCategories);
    }
}
