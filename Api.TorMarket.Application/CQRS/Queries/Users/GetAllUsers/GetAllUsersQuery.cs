using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

public sealed record GetAllUsersQuery : IRequest<IEnumerable<User?>>;
