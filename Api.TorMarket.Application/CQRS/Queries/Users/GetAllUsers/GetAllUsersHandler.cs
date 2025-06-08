using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

internal sealed class GetAllUsersHandler(
    IUserRepository userRepository
) : IRequestHandler<GetAllUsersQuery, IEnumerable<User?>>
{
    public async Task<IEnumerable<User?>> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken
    ) => await userRepository.GetAllAsync(cancellationToken);
}
