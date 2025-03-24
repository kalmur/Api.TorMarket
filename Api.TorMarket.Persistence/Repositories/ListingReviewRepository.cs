using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using ListingReviewEntity = Api.TorMarket.Persistence.Entities.ListingReviewEntity;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingReviewRepository(IApplicationDbContext context) : IListingReviewRepository
{
    public async Task<ListingReview?> GetReviewById(
        int id, 
        CancellationToken cancellationToken
    ) =>
        await context.ListingReview.FirstOrDefaultAsync(x =>
            x.ListingReviewId == id, 
            cancellationToken
        ).ToModel();

    public async Task<ListingReviewEntity?> DeleteReview(
        int id, 
        CancellationToken cancellationToken
    ) =>
        await context.ListingReview.FirstOrDefaultAsync(x =>
            x.ListingReviewId == id, 
            cancellationToken
        );

    public async Task AddReviewAsync(
        ListingReviewEntity review, 
        CancellationToken ct
    )
    {
        context.ListingReview.Add(review);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveReviewAsync(
        ListingReviewEntity review, 
        CancellationToken ct
    )
    {
        context.ListingReview.Remove(review);
        await context.SaveChangesAsync(ct);
    }
}
