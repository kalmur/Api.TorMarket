using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using User = Api.TorMarket.Domain.Models.User;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public sealed class CreateUserHandler : ICommandHandler<CreateUserCommand, ResultOrError<User, CreateUserFailure>>
{
    private readonly IValidator<CreateUserCommand, CreateUserFailure> _validator;
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(
        IValidator<CreateUserCommand, CreateUserFailure> validator,
        IUserRepository userRepository
    )
    {
        _validator = validator;
        _userRepository = userRepository;
    }

    public async Task<ResultOrError<User, CreateUserFailure>> HandleAsync(
        CreateUserCommand command, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await _validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await _userRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}