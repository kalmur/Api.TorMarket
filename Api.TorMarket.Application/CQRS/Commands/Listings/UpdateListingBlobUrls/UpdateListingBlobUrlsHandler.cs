using Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;


internal class UpdateListingBlobUrlsHandler(
    IListingRepository repository
) : IRequestHandler<UpdateListingBlobUrlsCommand, Listing>
{
    public async Task<Listing> Handle(
        UpdateListingBlobUrlsCommand request, 
        CancellationToken cancellationToken
    ) =>
        await repository.UpdateBlobUrlsAsync(
            request.ListingId,
            request.BlobUrl,
            cancellationToken
         );
}
