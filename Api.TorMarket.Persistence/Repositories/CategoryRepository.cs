using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext _context;

    public CategoryRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetCategoryById(int id, CancellationToken ct)
    {
        return await _context.Category.FirstOrDefaultAsync(x => 
            x.CategoryId == id, ct);
    }

    public async Task<Category?> DeleteCategory(int id, CancellationToken ct)
    {
        return await _context.Category.FirstOrDefaultAsync(x =>
            x.CategoryId == id, ct);
    }

    public async Task AddCategoryAsync(Category category, CancellationToken ct)
    {
        _context.Category.Add(category);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveCategoryAsync(Category category, CancellationToken ct)
    {
         _context.Category.Remove(category);
         await _context.SaveChangesAsync(ct);
    }
}
