using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Extensions;
using Api.TorMarket.Persistence.QuickRepo;
using System.Linq.Expressions;
using Api.TorMarket.Persistence.Abstractions;

namespace Api.TorMarket.Persistence.Repositories;

internal sealed class CategoryRepository : QuickRepo<CategoryEntity>, ICategoryRepository
{
    private readonly IApplicationDbContext _context;

    public CategoryRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) => await GetCategory(
        category => category.Name == name,
        cancellationToken
    );

    public async Task<IEnumerable<Category>> GetAllAsync(
       CancellationToken cancellationToken
    ) => await GetCategories(
        null,
        cancellationToken
    );

    // Private methods
    private IQueryable<CategoryEntity> CategoryQuery
        => _context.Category;

    private async Task<Category?> GetCategory(
        Expression<Func<CategoryEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQuerySingleOrDefaultAsync(
        CategoryQuery,
        predicate,
        category => category.ToModel()!,
        cancellationToken
    );

    private async Task<IEnumerable<Category>> GetCategories(
        Expression<Func<CategoryEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQueryAsync(
        CategoryQuery,
        predicate,
        category => category.ToModel()!,
        cancellationToken
    );
}
