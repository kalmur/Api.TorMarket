using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Interfaces.Repository;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ProductCategoryRepository(IApplicationDbContext context) : IProductCategoryRepository
{
    //public async Task<Category?> GetCategoryById(int id, CancellationToken cancellationToken) => 
    //    await context.ProductCategory
    //        .Where(x => x.Id == id)
    //        .Select(pc => new CategoryModel
    //        {
    //            CategoryId = pc.Id,
    //            Name = pc.Name
    //        })
    //        .FirstOrDefaultAsync(cancellationToken);

    public async Task AddCategoryAsync(ProductCategoryEntity categoryEntity, CancellationToken cancellationToken)
    {
        context.ProductCategory.Add(categoryEntity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveCategoryAsync(ProductCategoryEntity categoryEntity, CancellationToken cancellationToken)
    {
         context.ProductCategory.Remove(categoryEntity);
         await context.SaveChangesAsync(cancellationToken);
    }
}
