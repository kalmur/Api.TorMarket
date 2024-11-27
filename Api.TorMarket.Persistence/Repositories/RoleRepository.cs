using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Models;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class RoleRepository(IApplicationDbContext context) : IRoleRepository
{
    public async Task<RoleModel?> GetRoleById(int id, CancellationToken ct)
    {
        var role = await context.Role
            .FirstOrDefaultAsync(x => 
                x.RoleId == id, 
                ct
            );

        return role?.ToModel();
    }

    public async Task AddRoleAsync(Role role, CancellationToken ct)
    {
        context.Role.Add(role);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveRoleAsync(Role role, CancellationToken ct)
    {
        context.Role.Remove(role);
        await context.SaveChangesAsync(ct);
    }
}
