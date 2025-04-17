using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingRepository
{
    Task<Listing> CreateAsync(CreateListingRequest request, CancellationToken ct);
    Task<IEnumerable<ListingWithUserAndCategory>> GetAllInRandomOrder(CancellationToken ct);
    Task<Listing?> GetByIdAsync(int productId, CancellationToken ct);
    Task<List<ListingWithCategory>> GetByNameAsync(string name, CancellationToken ct);
    Task<List<ListingWithCategory>> GetByProviderIdAsync(string providerId, CancellationToken ct);
    Task<IEnumerable<ListingWithCategory?>> GetByCategoryNameAsync(string categoryName, CancellationToken ct);
}
