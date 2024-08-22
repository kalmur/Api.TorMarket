using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly IApplicationDbContext _context;

    public ReviewRepository(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Review?> GetReviewById(int id, CancellationToken ct)
    {
        return await _context.Reviews.FirstOrDefaultAsync(x =>
            x.ReviewId == id, ct);
    }

    public async Task<Review?> DeleteReview(int id, CancellationToken ct)
    {
        return await _context.Reviews.FirstOrDefaultAsync(x =>
            x.ReviewId == id, ct);
    }

    public async Task AddReviewAsync(Review review, CancellationToken ct)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveReviewAsync(Review review, CancellationToken ct)
    {
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync(ct);
    }
}
