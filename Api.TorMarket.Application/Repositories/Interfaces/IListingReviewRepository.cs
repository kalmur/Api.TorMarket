using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingReviewRepository
{
    Task<ListingReview?> GetReviewById(int id, CancellationToken cancellationToken);
    Task<ListingReview?> DeleteReview(int id, CancellationToken cancellationToken);
    Task AddReviewAsync(CreateListingReviewRequest review, CancellationToken ct);
    Task RemoveReviewAsync(CreateListingReviewRequest review, CancellationToken ct);
}
