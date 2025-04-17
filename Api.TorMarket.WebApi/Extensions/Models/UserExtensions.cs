using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;

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
        this User user
    ) => new()
    {
        UserId = user.UserId,
        ProviderId = user.ProviderId
    };
}