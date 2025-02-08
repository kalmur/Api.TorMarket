using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.Repositories;

public class SiteUserRepository(IApplicationDbContext context) : ISiteUserRepository
{
    public async Task AddUserAsync(SiteUser user, CancellationToken ct)
    {
        context.SiteUser.Add(user);
        await context.SaveChangesAsync(ct);
    }
}
