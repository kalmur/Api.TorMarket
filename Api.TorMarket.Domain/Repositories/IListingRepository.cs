using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Domain.Repositories;

public interface IListingRepository
{
    Task AddListing(Listing listing, CancellationToken ct);
}
