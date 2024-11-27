using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class Review : AuditableEntity
{
    public int ReviewId { get; set; }
    public required int UserId { get; set; }
    public required int ListingId { get; set; }
    public required int Rating { get; set; }
    public string? Comment { get; set; }

    public virtual User User { get; set; }
    public virtual Listing Listing { get; }
}
