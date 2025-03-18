using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    Task<ListingCategory?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
