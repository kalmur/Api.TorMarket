using Api.TorMarket.Application.Repositories;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Extensions;
using Api.TorMarket.Persistence.QuickRepo;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingRepository(
    IApplicationDbContext context
) : QuickRepoPageable<ListingEntity>, IListingRepository
{
    protected override uint MaximumPageSize => 50;
    protected override IReadOnlyDictionary<string, IOrderBy> OrderFunctions => ListingOrderFunctions;
    protected override IOrderBy DefaultOrderFunction => DefaultListingOrderFunction;

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
        ) ?? throw new InvalidOperationException("Listing creation failed.");
    }

    public async Task<Listing> UpdateBlobUrlsAsync(
       int listingId,
       string blobUrl,
       CancellationToken cancellationToken
    )
    {
        var listing = await context.Listing
            .Include(listing => listing.ListingBlobs)
            .SingleOrDefaultAsync(
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
        ) ?? throw new InvalidOperationException("Updating Blob Urls failed.");
    }

    public async Task<PaginatedResult<ListingWithDetails>> GetAllPaginatedAsync(
        PaginatedRequest paginatedRequest,
        CancellationToken cancellationToken
    ) => await GetListingsPaginated(
        null,
        paginatedRequest,
        cancellationToken
    );

    public async Task<ListingWithDetails?> GetByIdAsync(
        int listingId,
        CancellationToken cancellationToken
    ) => await GetListing(
        listing => listing.ListingId == listingId,
        cancellationToken
    );

    public async Task<IEnumerable<ListingWithDetails?>> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) => await GetListings(
        listing => listing.Title.ToLower().Contains(
            name.ToLower()
        ),
        cancellationToken
    );

    public async Task<IEnumerable<ListingWithDetails?>> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) => await GetListings(
        listing => listing.User.ProviderId == providerId,
        cancellationToken
    );

    public async Task<IEnumerable<ListingWithDetails?>> GetByCategoryNameAsync(
        string categoryName,
        CancellationToken cancellationToken
    ) => await GetListings(
        listing => listing.Category.Name.ToLower().Contains(
            categoryName.ToLower()
        ),
        cancellationToken
    );

    public async Task<bool> ListingExists(
        int userId, 
        string listingName, 
        CancellationToken cancellationToken
    ) => await context.Listing.AnyAsync(
        listing => listing.User.UserId == userId &&
                   listing.Title.ToLower() == listingName.ToLower(),
        cancellationToken
    );

    // Private methods
    private IQueryable<ListingEntity> ListingQuery
        => context.Listing
            .Include(listing => listing.User)
            .Include(listing => listing.Category)
            .Include(listing => listing.ListingBlobs);

    private async Task<ListingWithDetails?> GetListing(
        Expression<Func<ListingEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQuerySingleOrDefaultAsync(
        ListingQuery,
        predicate,
        listing => listing.ToListingWithDetails(),
        cancellationToken
    );

    private async Task<IEnumerable<ListingWithDetails>> GetListings(
        Expression<Func<ListingEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQueryAsync(
        ListingQuery,
        predicate,
        listing => listing.ToListingWithDetails(),
        cancellationToken
    );

    private async Task<PaginatedResult<ListingWithDetails>> GetListingsPaginated(
        Expression<Func<ListingEntity, bool>>? predicate,
        PaginatedRequest pagination,
        CancellationToken cancellationToken
    ) => await ExecutePaginatedQueryAsync(
        ListingQuery,
        predicate,
        listing => listing.ToListingWithDetails(),
        pagination,
        cancellationToken
    );

    private static readonly ReadOnlyDictionary<string, IOrderBy> ListingOrderFunctions = new(
        new Dictionary<string, IOrderBy>(StringComparer.OrdinalIgnoreCase)
        {
            {
                nameof(Listing.Title),
                new OrderBy<string>(listing => listing.Title)
            },
            {
                nameof(Listing.Price),
                new OrderBy<decimal>(listing => listing.Price)
            }
        }
    );

    private static readonly IOrderBy DefaultListingOrderFunction = ListingOrderFunctions[
        nameof(Listing.Title)
    ];
}
