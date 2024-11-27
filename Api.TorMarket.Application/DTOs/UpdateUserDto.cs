using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.DTOs;

public record UpdateUserDto(
    string FirstName,
    string LastName,
    [EmailAddress] string Email,
    string PhoneNumber
);
