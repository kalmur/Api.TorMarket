using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Domain.Models.External;

public class CreateUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}
