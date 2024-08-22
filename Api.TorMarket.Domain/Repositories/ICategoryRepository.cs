using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryById(int id, CancellationToken ct);
    Task<Category?> DeleteCategory(int id, CancellationToken ct);
    Task AddCategoryAsync(Category category, CancellationToken ct);
    Task RemoveCategoryAsync(Category category, CancellationToken ct);
}
