using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> CreateAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken
    );

    //Task DeleteAsync(
    //    string providerId,
    //    CancellationToken cancellationToken
    //);

    Task<User?> GetByIdAsync(
        int userId, 
        CancellationToken cancellationToken
    );

    Task<User?> GetByProviderIdAsync(
        string providerId, 
        CancellationToken cancellationToken
    );

    Task<IEnumerable<User?>> GetAllAsync(
        CancellationToken cancellationToken
    );
}
