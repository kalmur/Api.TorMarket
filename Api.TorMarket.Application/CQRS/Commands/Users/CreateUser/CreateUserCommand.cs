using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public record CreateUserCommand : IRequest<ResultOrError<User, CreateUserFailure>>
{
    public required string ProviderId { get; init; }

    internal CreateUserRequest ToRequest()
        => new()
        {
            ProviderId = ProviderId
        };
}
