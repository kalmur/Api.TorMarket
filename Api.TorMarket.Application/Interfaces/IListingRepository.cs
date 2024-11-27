using Api.TorMarket.Application.Models;

namespace Api.TorMarket.Application.Interfaces;

public interface IListingRepository
{
    Task<IEnumerable<ListingModel>> GetAllListingsWithReviews(CancellationToken ct);
}
