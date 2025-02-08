using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.SeedData;

public static class ProductCategorySeedData
{
    public static readonly List<ProductCategory> ProductCategories =
    [
        new ProductCategory { Id = 1, Name = "Electronics" },
        new ProductCategory { Id = 2, Name = "Games" },
        new ProductCategory { Id = 3, Name = "Toys" },
        new ProductCategory { Id = 4, Name = "Clothing" },
        new ProductCategory { Id = 5, Name = "Vehicles" },
        new ProductCategory { Id = 6, Name = "Pets" },
        new ProductCategory { Id = 7, Name = "Other" },
    ];
}
