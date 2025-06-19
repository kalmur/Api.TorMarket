using Api.TorMarket.Application.Repositories.Interfaces;
using static Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing.CreateListingFailure;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed class CreateListingValidator : IValidator<CreateListingCommand, CreateListingFailure>
{
    private readonly IListingRepository _listingRepository;
    private readonly IUserRepository _userRepository;

    public CreateListingValidator(
        IListingRepository listingRepository,
        IUserRepository userRepository
    )
    {
        _listingRepository = listingRepository;
        _userRepository = userRepository;
    }

    public async Task<CreateListingFailure?> ValidateAsync(
        CreateListingCommand command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrWhiteSpace(command.Title))
            errors.Add(ErrorType.InvalidName);

        if (command.Price <= 0)
            errors.Add(ErrorType.InvalidPrice);

        if (await UserDoesNotExistAsync(command.UserId, cancellationToken))
            errors.Add(ErrorType.UserDoesNotExist);

        // Ensure idempotency
        if (await ListingAlreadyExistsAsync(command.UserId, command.Title, cancellationToken))
            errors.Add(ErrorType.ListingAlreadyExists);

        if (errors.Count > 0)
        {
            return new CreateListingFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> UserDoesNotExistAsync(
        int userId,
        CancellationToken cancellationToken
    ) => 
        await _userRepository.GetByIdAsync(
            userId, 
            cancellationToken
        )
     is null;

    private async Task<bool> ListingAlreadyExistsAsync(
        int userId,
        string listingName,
        CancellationToken cancellationToken
    ) => await _listingRepository.ListingExists(
        userId, 
        listingName, 
        cancellationToken
    );
}
