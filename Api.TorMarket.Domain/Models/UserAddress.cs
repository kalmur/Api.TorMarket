namespace Api.TorMarket.Domain.Models;

public record UserAddress
{
    public const int AddressLine_MaxLength = 100;
    public const int Country_MaxLength = 50;
    public const int City_MaxLength = 50;
    public const int PostalCode_MaxLength = 100;
}