using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

public sealed record GetAllUsersQuery : IQuery<IEnumerable<User?>>;
