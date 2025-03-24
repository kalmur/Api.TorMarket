using Api.TorMarket.Application.Repositories.Interfaces;

namespace Api.TorMarket.Application.Workflows.Users.Commands.CreateUser;

public class CreateUserValidator(
    IUserRepository userRepository
) : IValidator<CreateUserCommand, CreateUserFailure?>
{
    public async Task<CreateUserFailure?> ValidateAsync(
        CreateUserCommand command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrEmpty(command.ProviderId))
            errors.Add(ErrorType.InvalidProviderId);

        if (await UserExists(command, cancellationToken))
            errors.Add(ErrorType.UserAlreadyExists);

        if (errors.Count > 0)
        {
            return new CreateUserFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> UserExists(
        CreateUserCommand command,
        CancellationToken cancellationToken
    ) => (
        await userRepository.GetByProviderIdAsync(
            command.ProviderId, 
            cancellationToken
        )
    ) is not null;
}

