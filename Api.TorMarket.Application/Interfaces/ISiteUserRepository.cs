using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Interfaces;

public interface ISiteUserRepository
{
    Task AddUserAsync(SiteUser user, CancellationToken ct);
}
