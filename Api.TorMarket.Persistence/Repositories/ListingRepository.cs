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
            .Include(listing => listing.User)
            .Include(listing => listing.Category)
            .OrderBy(_ => Guid.NewGuid())
            .Select(listing => 
                listing.ToModelWithUserAndCategory()
            )
            .ToListAsync(cancellationToken);

    public async Task<ListingWithUserAndCategory> GetByIdAsync(
        int listingId,
        CancellationToken cancellationToken
    ) => (
        await context.Listing
            .Include(listing => listing.User)
            .Include(listing => listing.Category)
            .FirstOrDefaultAsync(
                listing => listing.ListingId == listingId,
                cancellationToken
            )
    )?.ToModelWithUserAndCategory() ?? new ListingWithUserAndCategory();

    public async Task<List<ListingWithCategory>> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(listing => listing.Category)
            .Where(
                listing => listing.Name.ToLower().Contains(
                    name.ToLower()
                )
            )
            .Select(
                listing => listing.ToModelWithCategory()
            ).ToListAsync(cancellationToken);

    public async Task<List<ListingWithCategory>> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(listing => listing.User)
            .Include(listing => listing.Category)
            .Where(
                listing => listing.User.ProviderId == providerId
            )
            .Select(
                listing => listing.ToModelWithCategory()
            ).ToListAsync(cancellationToken);

    public async Task<IEnumerable<ListingWithCategory?>> GetByCategoryNameAsync(
        string categoryName,
        CancellationToken cancellationToken
    ) =>
        await context.Listing
            .Include(listing => listing.Category)
            .Where(
               listing => listing.Category.Name.ToLower().Contains(
                   categoryName.ToLower()
               )
            )
            .Select(
                listing => listing.ToModelWithCategory()
            ).ToListAsync(cancellationToken);

    public async Task<Listing> UpdateBlobUrlsAsync(
        int listingId,
        string blobUrl,
        CancellationToken cancellationToken
    )
    {
        var listing = await context.Listing
            .Include(
                listing => listing.ListingBlobs
            )
            .FirstOrDefaultAsync(
                listing => listing.ListingId == listingId, 
                cancellationToken
            ) ?? throw new InvalidOperationException($"Listing with ID {listingId} not found.");

        listing.ListingBlobs.AddBlob(
            listingId, 
            blobUrl, 
            isPrimary: true
        );

        await context.SaveChangesAsync(cancellationToken);

        return await GetByIdAsync(
            listing.ListingId,
            cancellationToken
        );
    }
}
