using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    Task<ProductCategory?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
