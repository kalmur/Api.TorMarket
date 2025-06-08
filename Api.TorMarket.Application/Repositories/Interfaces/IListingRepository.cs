using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingRepository
{
    Task<Listing> CreateAsync(
        CreateListingRequest request,
        CancellationToken cancellationToken
    );

    Task<Listing?> UpdateBlobUrlsAsync(
        int listingId,
        string blobUrl,
        CancellationToken cancellationToken
    );

    Task<IEnumerable<ListingWithDetails>> GetAllAsync(
        CancellationToken cancellationToken
    );

    Task<ListingWithDetails?> GetByIdAsync(
        int listingId,
        CancellationToken cancellationToken
    );

    Task<IEnumerable<ListingWithDetails?>> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    );

    Task<IEnumerable<ListingWithDetails?>> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    );

    Task<IEnumerable<ListingWithDetails?>> GetByCategoryNameAsync(
        string categoryName,
        CancellationToken cancellationToken
    );

    Task<bool> ListingExists(
        int userId,
        string listingName,
        CancellationToken cancellationToken
    );
}
