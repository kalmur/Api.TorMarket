using Api.TorMarket.Application.Abstractions.Azure;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed class CreateListingHandler : ICommandHandler<CreateListingCommand, ResultOrError<Listing, CreateListingFailure>>
{
    private readonly IValidator<CreateListingCommand, CreateListingFailure> _validator;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IListingRepository _listingRepository;
    private readonly IIndexingService _indexingService;

    public CreateListingHandler(
        IValidator<CreateListingCommand, CreateListingFailure> validator,
        ICategoryRepository categoryRepository,
        ICurrencyRepository currencyRepository,
        IListingRepository listingRepository,
        IIndexingService indexingService
    )
    {
        _validator = validator;
        _categoryRepository = categoryRepository;
        _currencyRepository = currencyRepository;
        _listingRepository = listingRepository;
        _indexingService = indexingService;
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


        var result = await _listingRepository.CreateAsync(
            command.ToRequest(
                category!.CategoryId,
                currency!.CurrencyId
            ),
            cancellationToken
        );

        // Add _textAnalyticsService AND _translatorService potentially

        var indexingResult = await _indexingService.UploadDataAsync(
            new SearchDocument
            {
                ListingId = result.ListingId.ToString(),
                ListingTitle = result.Title ?? string.Empty,
                ListingDescription = result.Description ?? ?? string.Empty
            },
            cancellationToken
        );

        if (!indexingResult)
        {
            // handle
        }

        return result;
    }
}