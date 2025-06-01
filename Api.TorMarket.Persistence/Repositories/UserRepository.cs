using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Extensions;
using Api.TorMarket.Persistence.QuickRepo;
using System.Linq.Expressions;

namespace Api.TorMarket.Persistence.Repositories;

internal class UserRepository(
    IApplicationDbContext context
) : QuickRepo<UserEntity>, IUserRepository
{
    public async Task<User?> GetByIdAsync(
        int userId, 
        CancellationToken cancellationToken
    ) => await GetUser(
        user => user.UserId == userId,
        cancellationToken
    );

    public async Task<User?> GetByProviderIdAsync(
        string providerId,
        CancellationToken cancellationToken
    ) => await GetUser(
        user => user.ProviderId == providerId,
        cancellationToken
    );

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

    // Private methods
    private IQueryable<UserEntity> UserQuery
        => context.User;

    private async Task<User?> GetUser(
        Expression<Func<UserEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQuerySingleOrDefaultAsync(
        UserQuery,
        predicate,
        user => user.ToModel()!,
        cancellationToken
    );
}
