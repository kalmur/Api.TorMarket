namespace Api.TorMarket.Persistence.Entities;

internal class ListingReviewEntity : AuditableEntity
{
    public int ListingReviewId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int RatingValue { get; set; }
    public string Comment { get; set; } = string.Empty;

    public virtual UserEntity User { get; set; } = null!;
    public virtual ListingEntity Product { get; set; } = null!;
}
