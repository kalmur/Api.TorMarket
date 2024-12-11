using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.SeedData;

public static class CategoryData
{
    public static readonly List<Category> Categories =
    [
        new Category { CategoryId = 1, Name = "Electronics", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
        new Category { CategoryId = 2, Name = "Games", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
        new Category { CategoryId = 3, Name = "Toys", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
        new Category { CategoryId = 4, Name = "Clothing", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
        new Category { CategoryId = 5, Name = "Vehicles", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
        new Category { CategoryId = 6, Name = "Pets", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
        new Category { CategoryId = 7, Name = "Other", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
    ];
}
