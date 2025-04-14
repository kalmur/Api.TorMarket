using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class UserRepository(IApplicationDbContext context) : IUserRepository
{
    public async Task<User> CreateUserAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken
    )
    {
        var user = request.ToEntity();

        context.User.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.ToModel();
    }

    public async Task<User?> GetByIdAsync(
        int userId, 
        CancellationToken cancellationToken
    ) => (
        await context.User.FirstOrDefaultAsync(u => 
            u.UserId == userId, 
            cancellationToken
        ))?.ToModel();

    public async Task<User?> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) => (
        await context.User.FirstOrDefaultAsync(u =>
            u.ProviderId == providerId,
            cancellationToken
        ))?.ToModel();
}
