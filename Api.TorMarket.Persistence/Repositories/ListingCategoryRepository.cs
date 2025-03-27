using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

internal class ListingCategoryRepository(
    IApplicationDbContext context
) : IListingCategoryRepository
{
    public async Task<ListingCategory?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    )
    {
        var category = await context.ListingCategory.FirstOrDefaultAsync(
            category => category.Name == name,
            cancellationToken
        );

        return category?.ToModel();
    }
}
