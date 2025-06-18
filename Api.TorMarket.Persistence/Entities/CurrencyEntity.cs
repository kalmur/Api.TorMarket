namespace Api.TorMarket.Persistence.Entities;

internal class CurrencyEntity
{
    internal int CurrencyId { get; set; } 
    internal required string Code { get; set; }
    internal required string Symbol { get; set; }
    internal required string Name { get; set; }

    internal virtual ICollection<ListingEntity> Listings { get; set; } = null!;
}
