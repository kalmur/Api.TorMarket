namespace Api.TorMarket.Persistence.Entities;

internal class CategoryEntity
{
    internal int CategoryId { get; set; }
    internal required string Name { get; set; }

    internal virtual ICollection<ListingEntity> Listings { get; set; } = null!;
}
