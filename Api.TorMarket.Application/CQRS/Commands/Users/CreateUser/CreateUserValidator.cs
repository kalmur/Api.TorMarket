using Api.TorMarket.Application.Repositories.Interfaces;

using static Api.TorMarket.Application.CQRS.Commands.Users.CreateUser.CreateUserFailure;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public sealed class CreateUserValidator : IValidator<CreateUserCommand, CreateUserFailure>
{
    private readonly IUserRepository _userRepository;

    public CreateUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserFailure?> ValidateAsync(
        CreateUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrEmpty(command.ProviderId))
            errors.Add(ErrorType.InvalidProviderId);

        // Ensure idempotency
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
    ) =>
        await _userRepository.GetByProviderIdAsync(
                command.ProviderId,
                cancellationToken
            )
            is not null;
}