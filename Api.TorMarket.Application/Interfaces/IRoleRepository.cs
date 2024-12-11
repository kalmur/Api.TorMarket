using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetRoleById(int id, CancellationToken ct);
    Task AddRoleAsync(Role role, CancellationToken ct);
    Task RemoveRoleAsync(Role role, CancellationToken ct);
}
