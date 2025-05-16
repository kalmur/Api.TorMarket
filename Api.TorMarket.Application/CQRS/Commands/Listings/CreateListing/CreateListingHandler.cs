using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

internal class CreateListingHandler(
    IValidator<CreateListingCommand, CreateListingFailure> validator,
    IListingRepository listingRepository,
    IBlobService blobService
) : IRequestHandler<CreateListingCommand, ResultOrError<Listing, CreateListingFailure>>
{
    public async Task<ResultOrError<Listing, CreateListingFailure>> Handle(
        CreateListingCommand command, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        var listing = await listingRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );

        if (command.ImageUrls is null) 
            return listing;

        var uploadTasks = command.ImageUrls
            .Select(
                imageUrl => blobService.UploadFileBlobAsync(
                    imageUrl,
                    $"{listing.ListingId}\\{Path.GetFileName(imageUrl)}",
                    cancellationToken
                )
            );

        await Task.WhenAll(uploadTasks);

        return listing;
    }
}