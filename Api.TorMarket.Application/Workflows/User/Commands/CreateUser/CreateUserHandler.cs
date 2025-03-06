using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public class CreateUserHandler(
    IValidator<CreateUserCommand, CreateUserFailure> validator
) : IRequestHandler<CreateUserCommand, ResultOrError<SiteUser, CreateUserFailure>>
{
    public Task<ResultOrError<SiteUser, CreateUserFailure>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}