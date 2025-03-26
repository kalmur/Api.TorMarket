using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

internal class CreateListingHandler(
    IValidator<CreateListingCommand, CreateListingFailure> validator,
    IListingRepository productRepository
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

        return await productRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}