namespace Api.TorMarket.Domain.Entities;

public class UserAddress
{
    public int UserId { get; set; }
    public int AddressId { get; set; }

    public virtual SiteUser User { get; set; } = null!;
    public virtual Address Address { get; set; } = null!;
}