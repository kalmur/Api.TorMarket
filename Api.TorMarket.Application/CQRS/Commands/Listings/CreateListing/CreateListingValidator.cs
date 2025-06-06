using Api.TorMarket.Application.Repositories.Interfaces;
using static Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing.CreateListingFailure;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed class CreateListingValidator(
    IListingRepository listingRepository,
    IUserRepository userRepository
) : IValidator<CreateListingCommand, CreateListingFailure>
{
    public async Task<CreateListingFailure?> ValidateAsync(
        CreateListingCommand command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrWhiteSpace(command.ListingName))
            errors.Add(ErrorType.InvalidName);

        if (command.Price <= 0)
            errors.Add(ErrorType.InvalidPrice);

        if (await UserDoesNotExistAsync(command.UserId, cancellationToken))
            errors.Add(ErrorType.UserDoesNotExist);

        // Ensure idempotency
        if (await ListingAlreadyExistsAsync(command.UserId, command.ListingName, cancellationToken))
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
        await userRepository.GetByIdAsync(
            userId, 
            cancellationToken
        )
     is null;

    private async Task<bool> ListingAlreadyExistsAsync(
        int userId,
        string listingName,
        CancellationToken cancellationToken
    ) => await listingRepository.ListingExists(
        userId, 
        listingName, 
        cancellationToken
    );
}
