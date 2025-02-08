using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Interfaces;

public interface IProductCategoryRepository
{
    Task<CategoryModel?> GetCategoryById(int id, CancellationToken cancellationToken);
    Task AddCategoryAsync(ProductCategory category, CancellationToken cancellationToken);
    Task RemoveCategoryAsync(ProductCategory category, CancellationToken cancellationToken);
}
