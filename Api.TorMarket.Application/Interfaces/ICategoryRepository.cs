using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryById(int id, CancellationToken ct);
    Task<Category?> DeleteCategory(int id, CancellationToken ct);
    Task AddCategoryAsync(Category category, CancellationToken ct);
    Task RemoveCategoryAsync(Category category, CancellationToken ct);
}
