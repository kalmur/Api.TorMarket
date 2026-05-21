using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

public sealed record GetAllUsersQuery : IQuery<IEnumerable<UserProfile>>;
