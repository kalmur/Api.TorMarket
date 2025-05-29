using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class UserExtensions
{
    public static User ToModel(
        this UserEntity entity
    ) => new()
    {
        UserId = entity.UserId,
        RoleId = entity.RoleId,
        ProviderId = entity.ProviderId
    };

    public static UserEntity ToEntity(
        this CreateUserRequest request
    ) => new()
    {
        RoleId = request.RoleId,
        ProviderId = request.ProviderId
    };
}
