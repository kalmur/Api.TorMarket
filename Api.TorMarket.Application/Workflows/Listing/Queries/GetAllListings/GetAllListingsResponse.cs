using Api.TorMarket.Application.DTOs;

namespace Api.TorMarket.Application.Workflows.Listing.Queries.GetAllListings
{
    public class GetAllListingsResponse
    {
        public IEnumerable<ListingWithReviewDto> Listings { get; }
    }
}
