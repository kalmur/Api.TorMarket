using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Interfaces.Repository;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.Repositories;

public class ProductRepository(IApplicationDbContext context) : IProductRepository
{
    public async Task AddListing(ProductEntity listing, CancellationToken cancellationToken)
    {
        context.Product.Add(listing);
        await context.SaveChangesAsync(cancellationToken);
    }
}
