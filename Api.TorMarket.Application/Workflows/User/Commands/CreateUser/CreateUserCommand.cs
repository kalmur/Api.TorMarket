using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public record CreateUserCommand : IRequest<ResultOrError<SiteUser,CreateUserFailure>>
{
    public int UserId { get; init; }
    public string ProviderId { get; init; }
}
