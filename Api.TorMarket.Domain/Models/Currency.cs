namespace Api.TorMarket.Domain.Models;

public sealed record Currency
{
    public const int Code_MaxLength = 50;
    public const int Symbol_MaxLength = 10;
    public const int Name_MaxLength = 100;

    public required int CurrencyId { get; set; }
    public required string Code { get; init; }
    public required string Symbol { get; init; }
    public required string Name { get; init; }
}
