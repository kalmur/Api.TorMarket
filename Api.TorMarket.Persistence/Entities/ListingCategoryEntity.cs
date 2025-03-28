namespace Api.TorMarket.Persistence.Entities;

internal class ListingCategoryEntity
{
    internal int ListingCategoryId { get; set; }
    internal string? Name { get; set; }

    internal virtual ICollection<ListingEntity> Products { get; set; } = null!;
}
