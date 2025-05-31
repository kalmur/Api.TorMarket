using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingRepository
{
    Task<Listing> CreateAsync(
        CreateListingRequest request,
        CancellationToken ct
    );

    Task<IEnumerable<ListingWithDetails>> GetAllInRandomOrder(
        CancellationToken ct
    );

    Task<ListingWithDetails> GetByIdAsync(
        int listingId, 
        CancellationToken ct
    );

    Task<List<ListingWithDetails>> GetByNameAsync(
        string name, 
        CancellationToken ct
    );

    Task<List<ListingWithDetails>> GetByProviderIdAsync(
        string providerId, 
        CancellationToken ct
    );

    Task<IEnumerable<ListingWithDetails?>> GetByCategoryNameAsync(
        string categoryName, 
        CancellationToken ct
    );

    Task<Listing> UpdateBlobUrlsAsync(
        int listingId,
        string blobUrl,
        CancellationToken cancellationToken
    );
}
