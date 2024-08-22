using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IApplicationDbContext _context;

    public RoleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetRoleById(int id, CancellationToken ct)
    {
        return await _context.Role.FirstOrDefaultAsync(x =>
            x.RoleId == id, ct);
    }

    public async Task AddRoleAsync(Role role, CancellationToken ct)
    {
        _context.Role.Add(role);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveRoleAsync(Role role, CancellationToken ct)
    {
        _context.Role.Remove(role);
        await _context.SaveChangesAsync(ct);
    }
}
