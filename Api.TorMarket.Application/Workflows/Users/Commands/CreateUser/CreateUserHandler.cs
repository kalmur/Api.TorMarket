using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Users.Commands.CreateUser;

public class CreateUserHandler(
    IValidator<CreateUserCommand, CreateUserFailure> validator,
    IUserRepository siteUserRepository
) : IRequestHandler<CreateUserCommand, ResultOrError<Domain.Models.User, CreateUserFailure>>
{
    public async Task<ResultOrError<Domain.Models.User, CreateUserFailure>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validationErrors = await validator.ValidateAsync(
            command, 
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await siteUserRepository.CreateUserAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}