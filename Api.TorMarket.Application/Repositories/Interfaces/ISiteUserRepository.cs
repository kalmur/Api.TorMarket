using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface ISiteUserRepository
{
    Task CreateUserAsync(SiteUserEntity user, CancellationToken cancellationToken);
    Task<SiteUser?> GetByIdAsync(int userId, CancellationToken cancellationToken);
}
