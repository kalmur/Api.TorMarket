using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingRepository
{
    Task<ListingWithDetails?> GetByIdAsync(
        int listingId, 
        CancellationToken ct
    );

    Task<IEnumerable<ListingWithDetails>> GetAllAsync(
       CancellationToken ct
   );


    Task<IEnumerable<ListingWithDetails?>> GetByNameAsync(
        string name, 
        CancellationToken ct
    );

    Task<IEnumerable<ListingWithDetails?>> GetByProviderIdAsync(
        string providerId, 
        CancellationToken ct
    );

    Task<IEnumerable<ListingWithDetails?>> GetByCategoryNameAsync(
        string categoryName, 
        CancellationToken ct
    );

    Task<Listing> CreateAsync(
        CreateListingRequest request,
        CancellationToken ct
    );

    Task<Listing?> UpdateBlobUrlsAsync(
        int listingId,
        string blobUrl,
        CancellationToken cancellationToken
    );
}
