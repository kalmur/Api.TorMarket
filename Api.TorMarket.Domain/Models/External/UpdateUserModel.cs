using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Domain.Models.External;

public class UpdateUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
