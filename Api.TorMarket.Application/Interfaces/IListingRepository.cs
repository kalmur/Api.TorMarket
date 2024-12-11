using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface IListingRepository
{
    Task AddListing(Listing listing, CancellationToken ct);
}
