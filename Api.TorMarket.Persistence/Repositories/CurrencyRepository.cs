using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Extensions;
using Api.TorMarket.Persistence.QuickRepo;
using System.Linq.Expressions;

namespace Api.TorMarket.Persistence.Repositories;

internal sealed class CurrencyRepository : QuickRepo<CurrencyEntity>, ICurrencyRepository
{
    private readonly IApplicationDbContext _context;

    public CurrencyRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Currency?> GetByCodeAync(
        string codeName,
        CancellationToken cancellationToken
    ) => GetCurrency(
        currency => currency.Code == codeName,
        cancellationToken
    );

    // Private methods
    private IQueryable<CurrencyEntity> CurrencyQuery
        => _context.Currency;

    private async Task<Currency?> GetCurrency(
        Expression<Func<CurrencyEntity, bool>>? predicate,
        CancellationToken cancellationToken
    ) => await ExecuteQuerySingleOrDefaultAsync(
        CurrencyQuery,
        predicate,
        currency => currency.ToModel(),
        cancellationToken
    );
}
