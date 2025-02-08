using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class UserProductReview : AuditableEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int? RatingValue { get; set; }
    public string? Comment { get; set; }

    public virtual SiteUser User { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}
