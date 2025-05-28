using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> CreateUserAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken
    );

    Task<User?> GetByIdAsync(
        int userId, 
        CancellationToken cancellationToken
    );

    Task<User?> GetByProviderIdAsync(
        string providerId, 
        CancellationToken cancellationToken
    );
}
