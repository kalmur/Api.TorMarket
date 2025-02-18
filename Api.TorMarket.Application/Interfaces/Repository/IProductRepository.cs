using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces.Repository;

public interface IProductRepository
{
    Task AddListing(ProductEntity listing, CancellationToken cancellationToken);
}
