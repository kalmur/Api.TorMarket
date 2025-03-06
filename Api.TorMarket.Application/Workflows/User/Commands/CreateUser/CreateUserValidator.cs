using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;

namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public class CreateUserValidator(ISiteUserRepository userRepository) : IValidator<CreateUserCommand, CreateUserFailure>
{
    public async Task<CreateUserFailure> ValidateAsync(CreateUserCommand command, CancellationToken cancellationToken)
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

    public async Task<bool> UserExists(
        CreateUserCommand command,
        CancellationToken cancellationToken
    ) => (
        await userRepository.GetByIdAsync(
            command.UserId, 
            cancellationToken
        )
    ) is not null;
}

