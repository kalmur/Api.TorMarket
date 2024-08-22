using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Domain.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user, CancellationToken ct);
}
