using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class MapperExtensions
{
    public static UserModel ToModel(this UpdateUserDto dto)
    {
        return new UserModel
        {
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
        };
    }
}
