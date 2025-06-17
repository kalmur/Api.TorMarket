using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;

public sealed class UpdateListingBlobUrlsHandler(
    IListingRepository repository
) : ICommandHandler<UpdateListingBlobUrlsCommand, Listing>
{
    public async Task<Listing> HandleAsync(
        UpdateListingBlobUrlsCommand command, 
        CancellationToken cancellationToken
    ) =>
        await repository.UpdateBlobUrlsAsync(
            command.ListingId,
            command.BlobUrl,
            cancellationToken
        );
}
