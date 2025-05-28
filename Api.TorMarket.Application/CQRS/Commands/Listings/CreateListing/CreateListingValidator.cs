using Api.TorMarket.Application.Repositories.Interfaces;
using static Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing.CreateListingFailure;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed class CreateListingValidator(
    IUserRepository userRepository
) : IValidator<CreateListingCommand, CreateListingFailure>
{
    public async Task<CreateListingFailure?> ValidateAsync(
        CreateListingCommand command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (await UserDoesNotExist(command.UserId, cancellationToken))
            errors.Add(ErrorType.UserDoesNotExist);


        if (string.IsNullOrWhiteSpace(command.Name))
            errors.Add(ErrorType.InvalidName);

        if (command.CategoryId == 0)
            errors.Add(ErrorType.InvalidCategoryId);

        if (command.Price <= 0)
            errors.Add(ErrorType.InvalidPrice);

        if (errors.Count > 0)
        {
            return new CreateListingFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> UserDoesNotExist(
        int userId,
        CancellationToken cancellationToken
    ) => 
        await userRepository.GetByIdAsync(
            userId, 
            cancellationToken
        )
     is null;
}
