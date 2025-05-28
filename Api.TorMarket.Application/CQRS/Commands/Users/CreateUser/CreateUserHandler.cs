using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using MediatR;
using User = Api.TorMarket.Domain.Models.User;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public sealed class CreateUserHandler(
    IValidator<CreateUserCommand, CreateUserFailure> validator,
    IUserRepository userRepository
) : IRequestHandler<CreateUserCommand, ResultOrError<User, CreateUserFailure>>
{
    public async Task<ResultOrError<User, CreateUserFailure>> Handle(
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

        return await userRepository.CreateUserAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}