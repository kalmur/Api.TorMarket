using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal sealed class CategoryRepository(
    IApplicationDbContext context
) : ICategoryRepository
{
    public async Task<List<Category>> GetAllAsync(
        CancellationToken cancellationToken
    ) =>
        await context.Category
            .AsNoTracking()
            .Select(category => category.ToModel()!)
            .ToListAsync(cancellationToken);

    public async Task<Category?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) =>
        (
            await context.Category.FirstOrDefaultAsync(
                category => category.Name == name,
                cancellationToken
            )
        )?.ToModel();
}
