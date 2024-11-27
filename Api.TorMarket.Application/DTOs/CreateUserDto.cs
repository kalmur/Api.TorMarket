using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.DTOs;

public record CreateUserDto(
    string FirstName,
    string LastName,
    [Required] [EmailAddress] string Email,
    string PhoneNumber,
    int RoleId
);