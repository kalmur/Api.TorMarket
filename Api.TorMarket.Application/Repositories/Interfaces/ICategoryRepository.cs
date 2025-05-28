using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync(
        CancellationToken cancellationToken
    );

    Task<Category?> GetByNameAsync(
        string name, 
        CancellationToken cancellationToken
    );
}
