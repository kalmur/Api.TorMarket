using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

public sealed class GetAllUsersHandler(
    IUserRepository userRepository
) : IQueryHandler<GetAllUsersQuery, IEnumerable<User?>>
{
    public async Task<IEnumerable<User?>> HandleAsync(
        GetAllUsersQuery request,
        CancellationToken cancellationToken
    ) => await userRepository.GetAllAsync(cancellationToken);
}