namespace Api.TorMarket.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int SellLease { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }

    public virtual ProductCategory ProductCategory { get; set; } = null!;
    public virtual ICollection<UserProductReview> UserProductReviews { get; set; } = null!;
}
