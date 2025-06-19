using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

public sealed class GetAllUsersHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<User?>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User?>> HandleAsync(
        GetAllUsersQuery request,
        CancellationToken cancellationToken
    ) => await _userRepository.GetAllAsync(cancellationToken);
}