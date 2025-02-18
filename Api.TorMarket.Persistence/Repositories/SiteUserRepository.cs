using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Interfaces.Repository;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.Repositories;

public class SiteUserRepository(IApplicationDbContext context) : ISiteUserRepository
{
    public async Task AddUserAsync(SiteUserEntity user, CancellationToken ct)
    {
        context.SiteUser.Add(user);
        await context.SaveChangesAsync(ct);
    }
}
