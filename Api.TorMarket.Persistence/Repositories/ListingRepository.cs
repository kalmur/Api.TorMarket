using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingRepository(
    IApplicationDbContext context
) : IListingRepository
{
    public async Task<Listing> CreateAsync(
        CreateListingRequest request, 
        CancellationToken cancellationToken
    )
    {
        var listing = request.ToEntity();

        context.Listing.Add(listing);
        await context.SaveChangesAsync(cancellationToken);

        return await GetByIdAsync(
            listing.ListingId, 
            cancellationToken
        ) ?? throw new InvalidOperationException("Product creation failed.");
    }

    public async Task<IEnumerable<ListingWithUserAndCategory>> GetAllInRandomOrder(
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(l => l.User)
            .Include(l => l.ListingCategory)
            .OrderBy(_ => Guid.NewGuid())
            .Select(l => 
                l.ToModelWithUserAndCategory()
            )
            .ToListAsync(cancellationToken);

    public async Task<ListingWithUserAndCategory> GetByIdAsync(
        int listingId,
        CancellationToken cancellationToken
    ) => (
        await context.Listing
            .Include(p => p.User)
            .Include(p => p.ListingCategory)
            .FirstOrDefaultAsync(p => 
                p.ListingId == listingId,
                cancellationToken
            )
    )?.ToModelWithUserAndCategory() ?? new ListingWithUserAndCategory();

    public async Task<List<ListingWithCategory>> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(l => l.ListingCategory)
            .Where(
                l => l.Name.ToLower().Contains(
                    name.ToLower()
                )
            )
            .Select(
                l => l.ToModelWithCategory()
            ).ToListAsync(cancellationToken);

    public async Task<List<ListingWithCategory>> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(l => l.User)
            .Include(l => l.ListingCategory)
            .Where(l => l.User.ProviderId == providerId)
            .Select(
                l => l.ToModelWithCategory()
            ).ToListAsync(cancellationToken);

    public async Task<IEnumerable<ListingWithCategory?>> GetByCategoryNameAsync(
        string categoryName,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(l => l.ListingCategory)
            .Where(
               l => l.ListingCategory.Name.ToLower().Contains(
                   categoryName.ToLower()
                )
            )
            .Select(
                l => l.ToModelWithCategory()
            ).ToListAsync(cancellationToken);

    public async Task<Listing> UpdateBlobUrlsAsync(
        int listingId,
        IEnumerable<string> blobUrls,
        CancellationToken cancellationToken
    )
    {
        var listing = await context.Listing.FirstOrDefaultAsync(l => 
            l.ListingId == listingId, 
            cancellationToken
        ) ?? throw new InvalidOperationException($"Listing with ID {listingId} not found.");

        listing.BlobUrls = blobUrls.ToList();
        await context.SaveChangesAsync(cancellationToken);

        return await GetByIdAsync(
            listing.ListingId,
            cancellationToken
        );
    }
}
