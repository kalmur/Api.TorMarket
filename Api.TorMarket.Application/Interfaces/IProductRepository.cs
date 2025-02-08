using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface IProductRepository
{
    Task AddListing(Product listing, CancellationToken cancellationToken);
}
