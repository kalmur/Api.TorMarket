namespace Api.TorMarket.Persistence.Entities;

public class UserAddressEntity
{
    public int UserAddressId { get; set; }
    public int UserId { get; set; }
    public int UnitNumber { get; set; }
    public int StreetNumber { get; set; }
    public string? AddressLine { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool IsDefault { get; set; }

    public virtual UserEntity User { get; set; } = null!;
}
