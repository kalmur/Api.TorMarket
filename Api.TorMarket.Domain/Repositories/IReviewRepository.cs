using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Domain.Repositories;

public interface IReviewRepository
{
    Task<Review?> GetReviewById(int id, CancellationToken ct);
    Task<Review?> DeleteReview(int id, CancellationToken ct);
    Task AddReviewAsync(Review review, CancellationToken ct);
    Task RemoveReviewAsync(Review review, CancellationToken ct);
}
