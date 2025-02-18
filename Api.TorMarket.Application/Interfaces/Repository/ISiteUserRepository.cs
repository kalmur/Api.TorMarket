using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces.Repository;

public interface ISiteUserRepository
{
    Task AddUserAsync(SiteUserEntity user, CancellationToken ct);
}
