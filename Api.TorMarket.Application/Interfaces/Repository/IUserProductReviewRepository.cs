using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces.Repository;

public interface IUserProductReviewRepository
{
    Task<ProductReviewEntity?> GetReviewById(int id, CancellationToken cancellationToken);
    Task<ProductReviewEntity?> DeleteReview(int id, CancellationToken cancellationToken);
    Task AddReviewAsync(ProductReviewEntity review, CancellationToken ct);
    Task RemoveReviewAsync(ProductReviewEntity review, CancellationToken ct);
}
