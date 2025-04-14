using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingCategoryRepository
{
    Task<List<ListingCategory>> GetAllAsync(CancellationToken cancellationToken);
    Task<ListingCategory?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
