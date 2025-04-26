using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingReviewRepository(IApplicationDbContext context) : IListingReviewRepository
{
    public async Task<ListingWithReviewAndCategory> CreateAsync(CreateListingReviewRequest request, CancellationToken cancellationToken)
    {
        var review = request.ToEntity();

        context.ListingReview.Add(review);
        await context.SaveChangesAsync(cancellationToken);

        return await GetByUserAndListingIdAsync(
            review.UserId,
            review.ListingId,
            cancellationToken
        ) ?? throw new InvalidOperationException("Review creation failed.");
    }

    // CHANGE BACK FIRSTORDEFAULT
    public async Task<ListingWithReviewAndCategory?> GetByUserAndListingIdAsync(
        int userId,
        int listingId,
        CancellationToken cancellationToken
    ) => (
            await context.ListingReview
            .Include(lr => lr.User)
            .Include(lr => lr.Listing)
            .ThenInclude(l => l.ListingCategory)
            .FirstOrDefaultAsync(p => 
                p.UserId == userId && 
                p.ListingId == listingId,
                cancellationToken
            )
        )?.ToModel() ?? throw new InvalidOperationException("Review not found");

    public async Task<IEnumerable<ListingReview>> GetByListingIdAsync(
        int listingId,
        CancellationToken cancellationToken
    ) => (
            await context.ListingReview
                .Include(lr => lr.User)
                .Where(p => p.ListingId == listingId)
                .ToListAsync(cancellationToken))
                .Select(r => r.ToModel()
            );

}
