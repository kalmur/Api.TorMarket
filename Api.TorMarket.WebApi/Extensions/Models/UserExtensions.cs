using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class UserExtensions
{
    public static CreateUserCommand ToCommand(
        this CreateUserRequestDto dto
    ) => new()
    {
        RoleId = dto.RoleId,
        ProviderId = dto.ProviderId
    };

    public static UserDto ToResponseDto(
        this User user
    ) => new()
    {
        UserId = user.UserId,
        RoleId = user.RoleId,
        ProviderId = user.ProviderId
    };

    public static UserProfileDto ToResponseDto(
        this UserProfile profile
    ) => new()
    {
        UserId = profile.User.UserId,
        RoleId = profile.User.RoleId,
        ProviderId = profile.User.ProviderId,
        Email = profile.IdentityProfile?.Email,
        FirstName = profile.IdentityProfile?.FirstName,
        LastName = profile.IdentityProfile?.LastName
    };
}