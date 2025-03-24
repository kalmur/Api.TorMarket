using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingReviewRepository
{
    Task<ListingReviewEntity?> GetReviewById(int id, CancellationToken cancellationToken);
    Task<ListingReviewEntity?> DeleteReview(int id, CancellationToken cancellationToken);
    Task AddReviewAsync(ListingReviewEntity review, CancellationToken ct);
    Task RemoveReviewAsync(ListingReviewEntity review, CancellationToken ct);
}
