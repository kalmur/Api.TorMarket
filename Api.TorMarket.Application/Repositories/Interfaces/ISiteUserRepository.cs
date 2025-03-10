using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface ISiteUserRepository
{
    Task<SiteUser> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<SiteUser?> GetByIdAsync(int userId, CancellationToken cancellationToken);
    Task<SiteUser?> GetByProviderIdAsync(string providerId, CancellationToken cancellationToken);
}
