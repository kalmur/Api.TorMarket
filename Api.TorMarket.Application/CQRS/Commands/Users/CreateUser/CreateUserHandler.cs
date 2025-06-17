using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using User = Api.TorMarket.Domain.Models.User;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public sealed class CreateUserHandler(
    IValidator<CreateUserCommand, CreateUserFailure> validator,
    IUserRepository userRepository
) : ICommandHandler<CreateUserCommand, ResultOrError<User, CreateUserFailure>>
{
    public async Task<ResultOrError<User, CreateUserFailure>> HandleAsync(
        CreateUserCommand command, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await userRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}