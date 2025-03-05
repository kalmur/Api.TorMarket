using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Interfaces.Repository;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class SiteUserRepository(
    IApplicationDbContext context
) : ISiteUserRepository
{
    public async Task CreateUserAsync(
        SiteUserEntity user, 
        CancellationToken cancellationToken
    )
    {
        context.SiteUser.Add(user);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<SiteUser?> GetByIdAsync(
        int userId, 
        CancellationToken cancellationToken
    ) => (
        await context.SiteUser.FirstOrDefaultAsync(u => 
            u.UserId == userId, 
            cancellationToken
        ))?.ToModel();
}
