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

        if (command.FilePaths is not null && !command.FilePaths.Any())
        {
            var imageUrls = new List<string>();

            var uploadTasks = command.FilePaths
                .Select(
                    async filePath =>
                    {
                        var uniqueFileName = $"{listing.ListingId}/{Guid.NewGuid()}_{Path.GetFileName(filePath)}";

                        await blobService.UploadFileBlobAsync(
                            filePath,
                            uniqueFileName,
                            cancellationToken
                        );

                        var blobUrl = blobService.GenerateBlobUrl(uniqueFileName);
                        imageUrls.Add(blobUrl);
                    }
                );

            await Task.WhenAll(uploadTasks);
        }

        return listing;
    }
}