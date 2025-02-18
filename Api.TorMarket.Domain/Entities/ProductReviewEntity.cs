using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class ProductReviewEntity : AuditableEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int? RatingValue { get; set; }
    public string? Comment { get; set; }

    public virtual SiteUserEntity User { get; set; } = null!;
    public virtual ProductEntity Product { get; set; } = null!;
}
