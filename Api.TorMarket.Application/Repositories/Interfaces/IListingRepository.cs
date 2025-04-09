using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using System.Collections.Immutable;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingRepository
{
    Task<Listing> CreateAsync(CreateListingRequest request, CancellationToken cancellationToken);
    Task<ImmutableArray<ListingWithUserAndCategory>> GetAllInRandomOrder(CancellationToken cancellationToken);
    Task<Listing?> GetByIdAsync(int productId, CancellationToken cancellationToken);
    Task<ImmutableArray<Listing>> GetListingsForUserAsync(int userId, CancellationToken cancellationToken);
}
