using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class UserProductReviewRepository(IApplicationDbContext context) : IUserProductReviewRepository
{
    public async Task<UserProductReview?> GetReviewById(int id, CancellationToken cancellationToken) =>
        await context.UserProductReview.FirstOrDefaultAsync(x =>
            x.Id == id, 
            cancellationToken
        );

    public async Task<UserProductReview?> DeleteReview(int id, CancellationToken cancellationToken) =>
        await context.UserProductReview.FirstOrDefaultAsync(x =>
            x.Id == id, 
            cancellationToken
        );

    public async Task AddReviewAsync(UserProductReview review, CancellationToken ct)
    {
        context.UserProductReview.Add(review);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveReviewAsync(UserProductReview review, CancellationToken ct)
    {
        context.UserProductReview.Remove(review);
        await context.SaveChangesAsync(ct);
    }
}
