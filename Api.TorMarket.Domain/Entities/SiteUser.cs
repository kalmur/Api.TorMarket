namespace Api.TorMarket.Domain.Entities;

public class SiteUser
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? EmailAddress { get; set; }
    public string? ProviderId { get; set; }

    public virtual ICollection<UserProductReview> UserProductReviews { get; set; } = null!;
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = null!;
}
