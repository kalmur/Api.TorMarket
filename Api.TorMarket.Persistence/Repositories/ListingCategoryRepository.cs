using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal sealed class ListingCategoryRepository(
    IApplicationDbContext context
) : IListingCategoryRepository
{
    public async Task<List<ListingCategory>> GetAllAsync(
        CancellationToken cancellationToken
    ) =>
        await context.ListingCategory
            .AsNoTracking()
            .Select(category => category.ToModel()!)
            .ToListAsync(cancellationToken);

    public async Task<ListingCategory?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    ) =>
        (
            await context.ListingCategory.FirstOrDefaultAsync(
                category => category.Name == name,
                cancellationToken
            )
        )?.ToModel();
}
