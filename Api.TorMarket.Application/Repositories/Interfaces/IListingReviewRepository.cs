using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingReviewRepository
{
    Task<IEnumerable<ListingReview>> GetByListingIdAsync(
        int listingId, 
        CancellationToken cancellationToken
    );

    Task<ListingWithReviewAndCategory?> GetByUserAndListingIdAsync(
        int userId,
        int listingId,
        CancellationToken cancelationToken
    );

    Task<ListingWithReviewAndCategory?> CreateAsync(
       CreateListingReviewRequest review,
       CancellationToken cancelationToken
   );
}
