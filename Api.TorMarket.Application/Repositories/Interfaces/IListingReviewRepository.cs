using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingReviewRepository
{
    Task<ListingWithReviewAndCategory> CreateAsync(CreateListingReviewRequest review, CancellationToken ct);
    Task<ListingWithReviewAndCategory?> GetByReviewIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<ListingReview>> GetByListingIdAsync(int listingId, CancellationToken cancellationToken);
    Task<ListingReview?> GetByUserAndListingIdAsync(int userId, int listingId, CancellationToken cancellationToken);
}
