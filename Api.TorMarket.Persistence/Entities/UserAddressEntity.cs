namespace Api.TorMarket.Persistence.Entities;

internal class UserAddressEntity
{
    internal int UserAddressId { get; set; }
    internal int UserId { get; set; }
    internal int UnitNumber { get; set; }
    internal int StreetNumber { get; set; }
    internal string? AddressLine { get; set; }
    internal string? City { get; set; }
    internal string? PostalCode { get; set; }
    internal string? Country { get; set; }
    internal bool IsDefault { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
}
