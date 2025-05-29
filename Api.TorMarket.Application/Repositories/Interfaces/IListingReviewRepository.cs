using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingReviewRepository
{
    Task<ListingWithReviewAndCategory> CreateAsync(
        CreateListingReviewRequest review, 
        CancellationToken cancelationToken
    );

    Task<ListingWithReviewAndCategory?> GetByUserAndListingIdAsync(
        int userId, 
        int listingId, 
        CancellationToken cancelationToken
    );

    Task<IEnumerable<ListingReview>> GetByListingIdAsync(
        int listingId, 
        CancellationToken cancellationToken
    );
}
