using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public record CreateUserCommand : IRequest<ResultOrError<SiteUser,CreateUserFailure>>
{
    public required int UserId { get; init; }
    public required string ProviderId { get; init; }
}
