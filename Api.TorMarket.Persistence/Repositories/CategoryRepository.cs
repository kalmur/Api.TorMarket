using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Models;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class CategoryRepository(IApplicationDbContext context) : ICategoryRepository
{
    public async Task<CategoryModel?> GetCategoryById(int id, CancellationToken ct)
    {
        var category = await context.Category
            .FirstOrDefaultAsync(x => 
                x.CategoryId == id, 
                ct
            );

        return category?.ToModel();
    }

    public async Task<CategoryModel?> DeleteCategory(int id, CancellationToken ct)
    {
        var category = await context.Category
            .FirstOrDefaultAsync(x =>
                x.CategoryId == id, 
                ct
            );

        return category?.ToModel();
    }

    public async Task AddCategoryAsync(Category category, CancellationToken ct)
    {
        context.Category.Add(category);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveCategoryAsync(Category category, CancellationToken ct)
    {
         context.Category.Remove(category);
         await context.SaveChangesAsync(ct);
    }
}
