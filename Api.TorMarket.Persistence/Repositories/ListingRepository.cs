using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
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
        var listing = request.ToEntity();

        context.Listing.Add(listing);
        await context.SaveChangesAsync(cancellationToken);

        var createdProduct = await GetByIdAsync(
            listing.ListingId, 
            cancellationToken
        );

        return createdProduct 
               ?? throw new InvalidOperationException("Product creation failed.");
    }

    public async Task<IEnumerable<ListingWithUserAndCategory>> GetAllInRandomOrder(
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(p => p.User)
            .Include(p => p.ListingCategory)
            .OrderBy(_ => Guid.NewGuid())
            .Select(p => p.ToModelWithUserAndCategory())
            .ToListAsync(cancellationToken);

    public async Task<Listing?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken
    ) => (
        await context.Listing
            .Include(p => p.User)
            .Include(p => p.ListingCategory)
            .FirstOrDefaultAsync(p => 
                p.ListingId == productId,
                cancellationToken
            )
    )?.ToModel();

    public async Task<List<ListingWithCategory>> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(p => p.ListingCategory)
            .Where(p => p.Name.ToLower().Contains(name.ToLower()))
            .Select(p => p.ToModelWithCategory())
            .ToListAsync(cancellationToken);

    public async Task<List<ListingWithCategory>> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(p => p.User)
            .Include(p => p.ListingCategory)
            .Where(p => p.User.ProviderId == providerId)
            .Select(p => p.ToModelWithCategory())
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<ListingWithCategory?>> GetByCategoryNameAsync(
        string categoryName,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(p => p.ListingCategory)
            .Where(p => p.ListingCategory.Name == categoryName)
            .Select(p => p.ToModelWithCategory())
            .ToListAsync(cancellationToken);
}
