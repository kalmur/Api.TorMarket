namespace Api.TorMarket.Domain.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual IReadOnlyCollection<Product> Products { get; set; } = null!;
}
