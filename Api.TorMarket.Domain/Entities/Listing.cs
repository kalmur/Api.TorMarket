using Api.TorMarket.Application.Entities.Common;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Entities;

public class Listing : AuditableEntity
{
    public int ListingId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int SellLease { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public DateTime? AvailableFrom { get; set; }

    public virtual User User { get; set; }
    public virtual Category Category { get; set; }
    public virtual IReadOnlyCollection<Review> Reviews { get; set; }
    public virtual IReadOnlyCollection<Photo> Photos { get; set; }
}
