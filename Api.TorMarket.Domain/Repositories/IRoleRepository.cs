using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Domain.Repositories;

public interface IRoleRepository
{
    Task<Role?> GetRoleById(int id, CancellationToken ct);
    Task AddRoleAsync(Role role, CancellationToken ct);
    Task RemoveRoleAsync(Role role, CancellationToken ct);
}
