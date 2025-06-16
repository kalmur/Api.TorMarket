using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public sealed record CreateUserCommand : ICommand<ResultOrError<User, CreateUserFailure>>
{
    public required int RoleId { get; init; }
    public required string ProviderId { get; init; }

    internal CreateUserRequest ToRequest()
        => new()
        {
            RoleId = RoleId,
            ProviderId = ProviderId
        };
}
