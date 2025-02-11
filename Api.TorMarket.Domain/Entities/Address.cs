namespace Api.TorMarket.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public int UnitNumber { get; set; }
    public int StreetNumber { get; set; }
    public string? AddressLine { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = null!;
}
