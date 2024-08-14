﻿using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.DTOs;

public class UpdateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
