using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.TorMarket.Application.Workflows.Listing.CreateListing;

public class CreateListingHandler : IRequestHandler<CreateListingRequest, CreateListingResponse>
{
    private readonly IListingRepository _repository;
    private readonly ILogger<CreateListingHandler> _logger;

    public CreateListingHandler(IListingRepository repository, ILogger<CreateListingHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CreateListingResponse> Handle(CreateListingRequest request, CancellationToken cancellationToken)
    {
        var newListing = request.ToEntity();

        await _repository.AddListing(newListing, cancellationToken);
        
        _logger.LogInformation("Listing with ID: {listingId} created.", newListing.ListingId);

        return new CreateListingResponse(newListing.ListingId);
    }
}
