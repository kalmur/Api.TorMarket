using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class SiteUserRepository(
    IApplicationDbContext context
) : ISiteUserRepository
{
    public async Task<SiteUser> CreateUserAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken
    )
    {
        var user = request.ToEntity();

        context.SiteUser.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.ToModel();
    }

    public async Task<SiteUser?> GetByIdAsync(
        int userId, 
        CancellationToken cancellationToken
    ) => (
        await context.SiteUser.FirstOrDefaultAsync(u => 
            u.UserId == userId, 
            cancellationToken
        ))?.ToModel();

    public async Task<SiteUser?> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) => (
        await context.SiteUser.FirstOrDefaultAsync(u =>
            u.ProviderId == providerId,
            cancellationToken
        ))?.ToModel();
}
