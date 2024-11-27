using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Models;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ReviewRepository(IApplicationDbContext context) : IReviewRepository
{
    public async Task<ReviewModel?> GetReviewById(int id, CancellationToken ct)
    {
        var review = await context.Reviews
            .FirstOrDefaultAsync(x =>
                x.ReviewId == id, 
                ct
            );

        return review?.ToModel();
    }

    public async Task<ReviewModel?> DeleteReview(int id, CancellationToken ct)
    {
        var review = await context.Reviews
            .FirstOrDefaultAsync(x => 
                x.ReviewId == id, 
                ct
            );

        return review?.ToModel();
    }

    public async Task AddReviewAsync(Review review, CancellationToken ct)
    {
        context.Reviews.Add(review);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveReviewAsync(Review review, CancellationToken ct)
    {
        context.Reviews.Remove(review);
        await context.SaveChangesAsync(ct);
    }
}
