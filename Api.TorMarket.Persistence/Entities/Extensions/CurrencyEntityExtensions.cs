using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static  class CurrencyEntityExtensions
{
    public static Currency ToModel(
        this CurrencyEntity entity
    ) => new()
    {
        CurrencyId = entity.CurrencyId,
        Code = entity.Code,
        Name = entity.Name,
        Symbol = entity.Symbol
    };
}
