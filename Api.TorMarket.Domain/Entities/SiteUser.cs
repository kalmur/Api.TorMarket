namespace Api.TorMarket.Domain.Entities;

public class SiteUser
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? EmailAddress { get; set; }
    public string? ProviderId { get; set; }

    public virtual IReadOnlyCollection<UserProductReview> UserProductReviews { get; set; } = null!;
    public virtual IReadOnlyCollection<UserAddress> UserAddresses { get; set; } = null!;
}
