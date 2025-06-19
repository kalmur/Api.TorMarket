using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Extensions;
using Api.TorMarket.Persistence.QuickRepo;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class UserRepository : QuickRepo<UserEntity>, IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(
        CreateUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var user = request.ToEntity();

        _context.User.Add(user);

        await _context.SaveChangesAsync(cancellationToken);

        return await GetByIdAsync(
            user.UserId, 
            cancellationToken
        ) ?? throw new InvalidOperationException("Failed to locate user.");
    }

    public async Task DeleteAsync(
        string providerId,
        CancellationToken cancellationToken
    ) => await EntityFrameworkQueryableExtensions.ExecuteDeleteAsync(
        _context.User.Where(user => user.ProviderId == providerId),
        cancellationToken
    );

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

    public async Task<IEnumerable<User?>> GetAllAsync(
        CancellationToken cancellationToken
    ) => await GetUsers(
        null,
        cancellationToken
    );

    // Private methods
    private IQueryable<UserEntity> UserQuery
        => _context.User;

    private async Task<User?> GetUser(
        Expression<Func<UserEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQuerySingleOrDefaultAsync(
        UserQuery,
        predicate,
        user => user.ToModel()!,
        cancellationToken
    );

    private async Task<IEnumerable<User?>> GetUsers(
        Expression<Func<UserEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQueryAsync(
        UserQuery,
        predicate,
        user => user.ToModel(),
        cancellationToken
    );
}