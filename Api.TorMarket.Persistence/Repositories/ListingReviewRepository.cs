using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingReviewRepository(IApplicationDbContext context) : IListingReviewRepository
{
    public async Task<ListingWithReviewAndCategory> CreateAsync(CreateListingReviewRequest request, CancellationToken ct)
    {
        var review = request.ToEntity();

        context.ListingReview.Add(review);
        await context.SaveChangesAsync(ct);

        return new ListingWithReviewAndCategory();

        //return await GetByReviewIdAsync(
        //    review.ListingReviewId,
        //    ct
        //) ?? throw new InvalidOperationException("Review creation failed.");
    }

    // CHANGE BACK FIRSTORDEFAULT
    public async Task<ListingWithReviewAndCategory?> GetByReviewIdAsync(
        int reviewId,
        CancellationToken cancellationToken
    ) => (
            await context.ListingReview
            .Include(lr => lr.User)
            .Include(lr => lr.Listing)
            .ThenInclude(l => l.ListingCategory)
            .FirstOrDefaultAsync(
                p => p.UserId == reviewId,
                cancellationToken
            )
        )?.ToModel() ?? throw new InvalidOperationException("ListingReview not found");

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

    public async Task<ListingReview?> GetByUserAndListingIdAsync(
        int userId,
        int listingId,
        CancellationToken cancellationToken
    ) => (
            await context.ListingReview
                .Include(lr => lr.User)
                .FirstOrDefaultAsync(
                    lr => lr.UserId == userId && lr.ListingId == listingId,
                    cancellationToken
                )
        )?.ToModel();
}
