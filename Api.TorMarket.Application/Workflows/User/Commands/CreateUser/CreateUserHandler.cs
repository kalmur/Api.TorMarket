using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public class CreateUserHandler(
    IValidator<CreateUserCommand, CreateUserFailure> validator,
    ISiteUserRepository siteUserRepository
) : IRequestHandler<CreateUserCommand, ResultOrError<SiteUser, CreateUserFailure>>
{
    public async Task<ResultOrError<SiteUser, CreateUserFailure>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
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