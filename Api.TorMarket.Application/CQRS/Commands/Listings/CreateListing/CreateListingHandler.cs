using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed class CreateListingHandler : ICommandHandler<CreateListingCommand, ResultOrError<Listing, CreateListingFailure>>
{
    private readonly IValidator<CreateListingCommand, CreateListingFailure> _validator;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IListingRepository _listingRepository;

    public CreateListingHandler(
        IValidator<CreateListingCommand, CreateListingFailure> validator,
        ICategoryRepository categoryRepository,
        ICurrencyRepository currencyRepository,
        IListingRepository listingRepository)
    {
        _validator = validator;
        _categoryRepository = categoryRepository;
        _currencyRepository = currencyRepository;
        _listingRepository = listingRepository;
    }

    public async Task<ResultOrError<Listing, CreateListingFailure>> HandleAsync(
        CreateListingCommand command, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await _validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        var category = await _categoryRepository.GetByNameAsync(
            command.CategoryName,
            cancellationToken
        );

        var currency = await _currencyRepository.GetByCodeAync(
            command.CurrencyCode,
            cancellationToken
        );

        return await _listingRepository.CreateAsync(
            command.ToRequest(
                category!.CategoryId,
                currency!.CurrencyId
            ),
            cancellationToken
        );
    }
}