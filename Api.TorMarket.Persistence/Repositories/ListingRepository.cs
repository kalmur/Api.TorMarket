using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using System.Collections.Immutable;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingRepository(IApplicationDbContext context) : IListingRepository
{
    public async Task<Listing> CreateAsync(
        CreateListingRequest request, 
        CancellationToken cancellationToken
    )
    {
        var product = request.ToEntity();

        context.Listing.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        var createdProduct = await GetByIdAsync(product.ListingId, cancellationToken);

        return createdProduct 
               ?? throw new InvalidOperationException("Product creation failed.");
    }

    public async Task<Listing?> GetByIdAsync(
        int productId, 
        CancellationToken cancellationToken
    ) => (
        await context.Listing
            .Include(p => p.User)
            .Include(p => p.ProductCategoryEntity)
            .FirstOrDefaultAsync(p => 
                p.ListingId == productId, 
                cancellationToken
            )
    )?.ToModel();

    public async Task<ImmutableArray<Listing>> GetAllAsync(
        CancellationToken cancellationToken
    ) => (
        await context.Listing
            .Include(p => p.User)
            .Include(p => p.ProductCategoryEntity)
            .Select(p => p.ToModel())
            .ToListAsync(cancellationToken)
    ).ToImmutableArray();
}
