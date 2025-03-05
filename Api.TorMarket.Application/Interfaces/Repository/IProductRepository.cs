using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Interfaces.Repository;

public interface IProductRepository
{
    Task<Product> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken);
}
