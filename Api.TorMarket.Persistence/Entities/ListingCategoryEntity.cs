namespace Api.TorMarket.Persistence.Entities;

public class ListingCategoryEntity
{
    public int ListingCategoryId { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<ListingEntity> Products { get; set; } = null!;
}
