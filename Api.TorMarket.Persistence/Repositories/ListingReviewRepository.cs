using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Extensions;
using Api.TorMarket.Persistence.QuickRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.TorMarket.Persistence.Repositories;

internal sealed class ListingReviewRepository(
    IApplicationDbContext context
) : QuickRepo<ListingReviewEntity>, IListingReviewRepository
{
    public async Task<ListingWithReviewAndCategory> CreateAsync(
        CreateListingReviewRequest request,
        CancellationToken cancellationToken
    )
    {
        var review = request.ToEntity();

        context.ListingReview.Add(review);
        await context.SaveChangesAsync(cancellationToken);

        return await GetByUserAndListingIdAsync(
            review.UserId,
            review.ListingId,
            cancellationToken
        ) ?? throw new InvalidOperationException("Could not locate review.");
    }

    public async Task<IEnumerable<ListingReview>> GetByListingIdAsync(
        int listingId,
        CancellationToken cancellationToken
    ) => await GetListingReviews(
        listingReview => listingReview.ListingId == listingId,
        cancellationToken
    );

    public async Task<ListingWithReviewAndCategory?> GetByUserAndListingIdAsync(
        int userId,
        int listingId,
        CancellationToken cancellationToken
    ) => await GetListingReview(
        listingReview => listingReview.UserId == userId && 
        listingReview.ListingId == listingId,
        cancellationToken
    );

    // Private methods
    private IQueryable<ListingReviewEntity> ListingReviewQuery
        => context.ListingReview
            .Include(lr => lr.User)
            .Include(lr => lr.Listing)
            .ThenInclude(l => l.Category);

    private async Task<ListingWithReviewAndCategory?> GetListingReview(
        Expression<Func<ListingReviewEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQuerySingleOrDefaultAsync(
        ListingReviewQuery,
        predicate,
        listingReview => listingReview.ToModel()!,
        cancellationToken
    );

    private async Task<IEnumerable<ListingWithReviewAndCategory>> GetListingReviews(
        Expression<Func<ListingReviewEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQueryAsync(
        ListingReviewQuery,
        predicate,
        listingReview => listingReview.ToModel()!,
        cancellationToken
    );
}
