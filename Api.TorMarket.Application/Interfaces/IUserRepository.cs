using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user, CancellationToken ct);
}
