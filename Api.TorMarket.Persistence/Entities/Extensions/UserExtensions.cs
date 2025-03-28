using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

<<<<<<<< HEAD:Api.TorMarket.Persistence/Entities/Extensions/UserExtensions.cs
internal static class UserExtensions
========
internal static class SiteUserEntityExtensions
>>>>>>>> f8f3b56d68edbc9497d2ebac4fad9ad486dc6822:Api.TorMarket.Persistence/Entities/Extensions/SiteUserEntityExtensions.cs
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
