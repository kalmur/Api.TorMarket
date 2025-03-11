namespace Api.TorMarket.Domain.Entities;

public class ProductCategoryEntity
{
    public int ProductCategoryId { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<ProductEntity> Products { get; set; } = null!;
}
