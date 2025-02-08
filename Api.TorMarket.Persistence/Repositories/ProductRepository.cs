using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.Repositories;

public class ProductRepository(IApplicationDbContext context) : IProductRepository
{
    public async Task AddListing(Product listing, CancellationToken cancellationToken)
    {
        context.Product.Add(listing);
        await context.SaveChangesAsync(cancellationToken);
    }
}
