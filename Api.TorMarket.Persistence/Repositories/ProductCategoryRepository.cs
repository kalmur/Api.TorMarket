using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ProductCategoryRepository(
    IApplicationDbContext context
) : IProductCategoryRepository
{
    public async Task<ProductCategory?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    )
    {
        var category = await context.ProductCategory.FirstOrDefaultAsync(
            category => category.Name == name,
            cancellationToken
        );

        return category?.ToModel();
    }
}
