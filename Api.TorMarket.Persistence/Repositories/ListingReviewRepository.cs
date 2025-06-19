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

internal sealed class ListingReviewRepository : QuickRepo<ListingReviewEntity>, IListingReviewRepository
{
    private readonly IApplicationDbContext _context;

    public ListingReviewRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ListingWithReviewAndCategory> CreateAsync(
        CreateListingReviewRequest request,
        CancellationToken cancellationToken
    )
    {
        var review = request.ToEntity();

        _context.ListingReview.Add(review);
        await _context.SaveChangesAsync(cancellationToken);

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
        => _context.ListingReview
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
