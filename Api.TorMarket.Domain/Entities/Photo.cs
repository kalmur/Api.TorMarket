using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class Photo : AuditableEntity
{
    public int PhotoId { get; set; }
    public int UserId { get; set; }
    public int ListingId { get; set; }
    public string Url { get; set; }
    public bool IsPrimary { get; set; }

    public virtual User User { get; set; }
    public virtual Listing Listing { get; set; }
}
