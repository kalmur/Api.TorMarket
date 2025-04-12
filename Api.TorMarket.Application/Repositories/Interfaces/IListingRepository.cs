using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingRepository
{
    Task<Listing> CreateAsync(CreateListingRequest request, CancellationToken cancellationToken);
    Task<IEnumerable<ListingWithUserAndCategory>> GetAllInRandomOrder(CancellationToken cancellationToken);
    Task<IEnumerable<ListingWithCategory?>> GetListingsForCategoryAsync(string categoryName, CancellationToken cancellationToken);
    Task<Listing?> GetByIdAsync(int productId, CancellationToken cancellationToken);
    Task<IEnumerable<Listing>> GetListingsForUserAsync(int userId, CancellationToken cancellationToken);
}
