using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed class CreateListingHandler(
    IValidator<CreateListingCommand, CreateListingFailure> validator,
    ICategoryRepository categoryRepository,
    ICurrencyRepository currencyRepository,
    IListingRepository listingRepository
) : ICommandHandler<CreateListingCommand, ResultOrError<Listing, CreateListingFailure>>
{
    public async Task<ResultOrError<Listing, CreateListingFailure>> HandleAsync(
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

        var category = await categoryRepository.GetByNameAsync(
            command.CategoryName,
            cancellationToken
        );

        var currency = await currencyRepository.GetByCodeAync(
            command.CurrencyCode,
            cancellationToken
        );

        return await listingRepository.CreateAsync(
            command.ToRequest(
                category!.CategoryId,
                currency!.CurrencyId
            ),
            cancellationToken
        );
    }
}