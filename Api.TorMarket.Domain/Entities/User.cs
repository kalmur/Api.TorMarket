namespace Api.TorMarket.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string ExternalId { get; set; }

    public virtual Role Role { get; set; }
    public virtual IReadOnlyCollection<Listing> Listings { get; set; }
    public virtual IReadOnlyCollection<Review> Reviews { get; set; }
    public virtual IReadOnlyCollection<Photo> Photos { get; set; }
}
