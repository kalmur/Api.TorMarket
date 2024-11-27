using Api.TorMarket.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.TorMarket.Application.Workflows.Listing.Queries.GetAllListings;

public class GetAllListingsHandler : IRequestHandler<GetAllListingsRequest, GetAllListingsResponse>
{
    private readonly IListingRepository _repository;
    private readonly ILogger<GetAllListingsHandler> _logger;

    public GetAllListingsHandler
    (
        IListingRepository repository,
        ILogger<GetAllListingsHandler> logger
    )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<GetAllListingsResponse> Handle(GetAllListingsRequest notification, CancellationToken cancellationToken)
    {
        await _repository.GetAllListingsWithReviews(cancellationToken);

        return null;
    }
}