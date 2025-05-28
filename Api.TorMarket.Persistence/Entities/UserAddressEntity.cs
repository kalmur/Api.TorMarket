namespace Api.TorMarket.Persistence.Entities;

internal class UserAddressEntity
{
    internal const int UserAddressEntity_CountryMaxLength = 50;
    internal const int UserAddressEntity_CityMaxLength = 50;
    internal const int UserAddressEntity_PostalCodeMaxLength = 100;

    internal int UserAddressId { get; set; }
    internal required int UserId { get; set; }
    internal required int UnitNumber { get; set; }
    internal required int StreetNumber { get; set; }
    internal required string AddressLine { get; set; }
    internal required string City { get; set; }
    internal required string PostalCode { get; set; }
    internal required string Country { get; set; }
    internal required bool IsDefault { get; set; }

    internal virtual UserEntity User { get; set; } = null!;
}
