using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IListingCategoryRepository
{
    Task<ListingCategory?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
