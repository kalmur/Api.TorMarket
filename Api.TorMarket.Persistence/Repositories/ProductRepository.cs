using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Interfaces.Repository;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ProductRepository(
    IApplicationDbContext context
) : IProductRepository
{
    public async Task<Product> CreateAsync(
        CreateProductRequest request, 
        CancellationToken cancellationToken
    )
    {
        var product = request.ToEntity();

        context.Product.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        var createdProduct = await GetByIdAsync(product.ProductId, cancellationToken);

        return createdProduct 
               ?? throw new InvalidOperationException("Product creation failed.");
    }

    public async Task<Product?> GetByIdAsync(
        int productId, 
        CancellationToken cancellationToken
    ) => (
        await context.Product
            .Include(p => p.User)
            .Include(p => p.ProductCategoryEntity)
            .FirstOrDefaultAsync(p => 
                p.ProductId == productId, 
                cancellationToken
            )
        )?.ToModel();
}
