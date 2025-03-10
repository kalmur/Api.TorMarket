using Api.TorMarket.Application.Workflows.User.Commands.CreateUser;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Results;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class UserExtensions
{
    public static CreateUserCommand ToCommand(this CreateUserRequestDto dto)
    {
        return new CreateUserCommand
        {
            ProviderId = dto.ProviderId
        };
    }

    public static UserDto ToResponseDto(
        this SiteUser user
    ) => new()
    {
        UserId = user.UserId,
        ProviderId = user.ProviderId
    };
}