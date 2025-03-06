using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class UserProductReviewRepository(IApplicationDbContext context) : IUserProductReviewRepository
{
    public async Task<ProductReviewEntity?> GetReviewById(int id, CancellationToken cancellationToken) =>
        await context.ProductReview.FirstOrDefaultAsync(x =>
            x.ProductReviewId == id, 
            cancellationToken
        );

    public async Task<ProductReviewEntity?> DeleteReview(int id, CancellationToken cancellationToken) =>
        await context.ProductReview.FirstOrDefaultAsync(x =>
            x.ProductReviewId == id, 
            cancellationToken
        );

    public async Task AddReviewAsync(ProductReviewEntity review, CancellationToken ct)
    {
        context.ProductReview.Add(review);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveReviewAsync(ProductReviewEntity review, CancellationToken ct)
    {
        context.ProductReview.Remove(review);
        await context.SaveChangesAsync(ct);
    }
}
