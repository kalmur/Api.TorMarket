using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Domain.Models;

public class UpdateUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
