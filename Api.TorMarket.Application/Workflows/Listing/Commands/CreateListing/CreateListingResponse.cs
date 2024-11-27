namespace Api.TorMarket.Application.Workflows.Listing.Commands.CreateListing;

public class CreateListingResponse
{
    public CreateListingResponse(int listingId)
    {
        ListingId = listingId;
    }

    public int ListingId { get; }
}
