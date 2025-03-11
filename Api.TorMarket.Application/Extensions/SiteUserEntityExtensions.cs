using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class SiteUserEntityExtensions
{
    public static User ToModel(
        this UserEntity entity
    ) => new()
    {
        UserId = entity.UserId,
        ProviderId = entity.ProviderId ?? string.Empty
    };

    public static UserEntity ToEntity(
        this CreateUserRequest request
    ) => new()
    {
        ProviderId = request.ProviderId
    };
}
