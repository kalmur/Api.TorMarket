using Api.TorMarket.Application.Unions;
using MediatR;

namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public record CreateUserCommand : IRequest<ResultOrError<Domain.Models.User, CreateUserFailure>>
{
    public required string ProviderId { get; init; }
}
