using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class SiteUserEntityExtensions
{
    public static SiteUser ToModel(this SiteUserEntity entity)
    {
        return new SiteUser
        {
            UserId = entity.UserId,
            ProviderId = entity.ProviderId ?? string.Empty
        };
    }
}
