using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class ProductReviewEntity : AuditableEntity
{
    public int ProductReviewId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int RatingValue { get; set; }
    public string Comment { get; set; } = string.Empty;

    public virtual UserEntity User { get; set; } = null!;
    public virtual ProductEntity Product { get; set; } = null!;
}
