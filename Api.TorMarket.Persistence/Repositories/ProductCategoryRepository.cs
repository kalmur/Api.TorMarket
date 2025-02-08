using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ProductCategoryRepository(IApplicationDbContext context) : IProductCategoryRepository
{
    public async Task<CategoryModel?> GetCategoryById(int id, CancellationToken cancellationToken) => 
        await context.ProductCategory
            .Where(x => x.Id == id)
            .Select(pc => new CategoryModel
            {
                CategoryId = pc.Id,
                Name = pc.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

    public async Task AddCategoryAsync(ProductCategory category, CancellationToken cancellationToken)
    {
        context.ProductCategory.Add(category);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveCategoryAsync(ProductCategory category, CancellationToken cancellationToken)
    {
         context.ProductCategory.Remove(category);
         await context.SaveChangesAsync(cancellationToken);
    }
}
