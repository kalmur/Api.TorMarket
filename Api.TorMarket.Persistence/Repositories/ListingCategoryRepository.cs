using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Repositories;

public class ListingCategoryRepository(
    IApplicationDbContext context
) : IProductCategoryRepository
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
