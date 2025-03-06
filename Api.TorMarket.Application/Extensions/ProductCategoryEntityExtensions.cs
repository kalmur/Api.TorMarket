using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class ProductCategoryEntityExtensions
{
    public static ProductCategory? ToModel(
        this ProductCategoryEntity entity
    ) => new()
    {
        ProductCategoryId = entity.ProductCategoryId,
        Name = entity.Name ?? string.Empty
    };
}
