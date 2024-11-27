using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ListingRepository(IApplicationDbContext context) : IListingRepository
{
    public async Task<IEnumerable<ListingModel>> GetAllListingsWithReviews(CancellationToken ct)
    {
        var listings = await context.Listings
            .Include(l => l.Reviews)
            .ToListAsync(ct);

        return listings.ToModel();
    }
}
