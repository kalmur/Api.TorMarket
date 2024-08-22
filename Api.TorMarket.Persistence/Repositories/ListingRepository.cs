using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Repositories;

namespace Api.TorMarket.Persistence.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly IApplicationDbContext _context;

    public ListingRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddListing(Listing listing, CancellationToken ct)
    {
        _context.Listings.Add(listing);
        await _context.SaveChangesAsync(ct);
    }
}
