using Api.TorMarket.Application.Models;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface IReviewRepository
{
    Task<ReviewModel?> GetReviewById(int id, CancellationToken ct);
    Task<ReviewModel?> DeleteReview(int id, CancellationToken ct);
    Task AddReviewAsync(Review review, CancellationToken ct);
    Task RemoveReviewAsync(Review review, CancellationToken ct);
}
