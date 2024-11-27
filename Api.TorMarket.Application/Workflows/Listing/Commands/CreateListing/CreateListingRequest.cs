using Api.TorMarket.Application.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Listing.Commands.CreateListing;

public class CreateListingRequest : IRequest<CreateListingResponse>
{
    public CreateListingRequest(CreateListingModel listing)
    {
        Listing = listing;
    }

    public CreateListingModel Listing { get; set; }
}
