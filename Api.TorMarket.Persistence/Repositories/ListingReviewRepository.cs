using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ListingReviewEntity = Api.TorMarket.Persistence.Entities.ListingReviewEntity;

namespace Api.TorMarket.Persistence.Repositories;

public class ListingReviewRepository(IApplicationDbContext context) : IListingReviewRepository
{
    public async Task<ListingReviewEntity?> GetReviewById(
        int id, 
        CancellationToken cancellationToken
    ) =>
        await context.ListingReview.FirstOrDefaultAsync(x =>
            x.ListingReviewId == id, 
            cancellationToken
        );

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
