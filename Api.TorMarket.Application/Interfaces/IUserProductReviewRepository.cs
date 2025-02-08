using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface IUserProductReviewRepository
{
    Task<UserProductReview?> GetReviewById(int id, CancellationToken cancellationToken);
    Task<UserProductReview?> DeleteReview(int id, CancellationToken cancellationToken);
    Task AddReviewAsync(UserProductReview review, CancellationToken ct);
    Task RemoveReviewAsync(UserProductReview review, CancellationToken ct);
}
