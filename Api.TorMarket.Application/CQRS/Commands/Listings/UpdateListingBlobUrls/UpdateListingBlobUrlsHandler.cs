using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;

public sealed class UpdateListingBlobUrlsHandler : ICommandHandler<UpdateListingBlobUrlsCommand, Listing>
{
    private readonly IListingRepository _repository;

    public UpdateListingBlobUrlsHandler(IListingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Listing> HandleAsync(
        UpdateListingBlobUrlsCommand command, 
        CancellationToken cancellationToken
    ) =>
        await _repository.UpdateBlobUrlsAsync(
            command.ListingId,
            command.BlobUrl,
            cancellationToken
        );
}
