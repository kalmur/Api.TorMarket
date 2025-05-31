using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
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

    public async Task<IEnumerable<ListingWithDetails>> GetAllInRandomOrder(
        CancellationToken cancellationToken
    ) =>
        await GetListingsWithDetails()
            .OrderBy(_ => Guid.NewGuid())
            .Select(listing => listing.ToListingWithDetails())
            .ToListAsync(cancellationToken);

    public async Task<ListingWithDetails> GetByIdAsync(
        int listingId,
        CancellationToken cancellationToken
    ) => (
        await GetListingsWithDetails()
            .FirstOrDefaultAsync(
                listing => listing.ListingId == listingId,
                cancellationToken
            )
    )?.ToListingWithDetails() ?? new ListingWithDetails();

    public async Task<List<ListingWithDetails>> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) =>
        await GetListingsWithDetails()
            .Where(
                listing => listing.Name.ToLower().Contains(
                    name.ToLower()
                )
            )
            .Select(
                listing => listing.ToListingWithDetails()
            ).ToListAsync(cancellationToken);

    public async Task<List<ListingWithDetails>> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) =>
        await GetListingsWithDetails()
            .Where(listing => listing.User.ProviderId == providerId)
            .Select(listing => listing.ToListingWithDetails())
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<ListingWithDetails?>> GetByCategoryNameAsync(
        string categoryName,
        CancellationToken cancellationToken
    ) =>
        await GetListingsWithDetails()
            .Where(
               listing => listing.Category.Name.ToLower().Contains(
                   categoryName.ToLower()
               )
            )
            .Select(
                listing => listing.ToListingWithDetails()
            ).ToListAsync(cancellationToken);

    public async Task<Listing> UpdateBlobUrlsAsync(
        int listingId,
        string blobUrl,
        CancellationToken cancellationToken
    )
    {
        var listing = await context.Listing
            .Include(listing => listing.ListingBlobs)
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

    private IQueryable<ListingEntity> GetListingsWithDetails()
    {
        return context.Listing
            .Include(listing => listing.User)
            .Include(listing => listing.Category)
            .Include(listing => listing.ListingBlobs);
    }

}
