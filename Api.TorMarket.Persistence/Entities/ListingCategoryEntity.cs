namespace Api.TorMarket.Persistence.Entities;

internal class ListingCategoryEntity
{
    internal const int Name_MaxLength = 15;

    internal int ListingCategoryId { get; set; }
    internal required string Name { get; set; }

    internal virtual ICollection<ListingEntity> Listings { get; set; } = null!;
}
