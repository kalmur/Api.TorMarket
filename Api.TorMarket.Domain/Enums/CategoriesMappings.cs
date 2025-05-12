namespace Api.TorMarket.Domain.Enums;

public static class CategoryMappings
{
    private static readonly Dictionary<Categories, string> _categoryToStringMap = new()
    {
        { Categories.Electronics, "Electronics" },
        { Categories.Games, "Games" },
        { Categories.Toys, "Toys" },
        { Categories.Clothing, "Clothing" },
        { Categories.Vehicles, "Vehicles" },
        { Categories.Pets, "Pets" },
        { Categories.Other, "Other" }
    };

    public static string GetStringValue(Categories category)
    {
        return _categoryToStringMap.TryGetValue(
            category, 
            out var stringValue
        ) 
            ? stringValue 
            : category.ToString();
    }
}
