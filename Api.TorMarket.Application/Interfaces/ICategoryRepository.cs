using Api.TorMarket.Application.Models;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryModel?> GetCategoryById(int id, CancellationToken ct);
    Task<CategoryModel?> DeleteCategory(int id, CancellationToken ct);
    Task AddCategoryAsync(Category category, CancellationToken ct);
    Task RemoveCategoryAsync(Category category, CancellationToken ct);
}
