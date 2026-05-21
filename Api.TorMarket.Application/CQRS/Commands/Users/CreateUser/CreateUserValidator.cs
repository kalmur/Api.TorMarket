using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Application.Repositories.Interfaces;

using static Api.TorMarket.Application.CQRS.Commands.Users.CreateUser.CreateUserFailure;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public sealed class CreateUserValidator : IValidator<CreateUserCommand, CreateUserFailure>
{
    private readonly IUserRepository _userRepository;
    private readonly IIdentityProviderService _identityProviderService;

    public CreateUserValidator(
        IUserRepository userRepository,
        IIdentityProviderService identityProviderService
    )
    {
        _userRepository = userRepository;
        _identityProviderService = identityProviderService;
    }

    public async Task<CreateUserFailure?> ValidateAsync(
        CreateUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrEmpty(command.ProviderId))
        {
            errors.Add(ErrorType.InvalidProviderId);
        }
        else if (!await ProviderUserExists(command.ProviderId, cancellationToken))
        {
            errors.Add(ErrorType.ProviderUserNotFound);
        }

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

    private async Task<bool> ProviderUserExists(
        string providerId,
        CancellationToken cancellationToken
    )
    {
        var users = await _identityProviderService.GetUsersInformationAsync(
            new[] { providerId },
            cancellationToken
        );

        return users.Any(
            u => string.Equals(u.ExternalProviderId, providerId, StringComparison.Ordinal)
        );
    }
}