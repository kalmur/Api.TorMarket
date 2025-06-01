using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken
    );

    Task<IEnumerable<Category>> GetAllAsync(
        CancellationToken cancellationToken
    );
}
