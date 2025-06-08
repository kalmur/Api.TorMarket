using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.TorMarket.Persistence.QuickRepo;

internal abstract class QuickRepo<TQueryable>
{
    protected static async Task<TResponse?> ExecuteQuerySingleOrDefaultAsync<TResponse>(
        IQueryable<TQueryable> query,
        Expression<Func<TQueryable, bool>>? predicate,
        Func<TQueryable, TResponse> convertToResponse,
        CancellationToken cancellationToken
    )
    {
        var result = await (
            predicate is null
                ? query.SingleOrDefaultAsync(cancellationToken)
                : query.SingleOrDefaultAsync(predicate, cancellationToken)
        );

        return result is null
            ? default
            : convertToResponse(result);
    }

    protected static async Task<IEnumerable<TResponse>> ExecuteQueryAsync<TResponse>(
        IQueryable<TQueryable> query,
        Expression<Func<TQueryable, bool>>? predicate,
        Func<TQueryable, TResponse> convertToResponse,
        CancellationToken cancellationToken
    ) => (
        await (
            predicate is not null
                ? query.Where(predicate)
                : query
        ).ToListAsync(cancellationToken)
    ).Select(convertToResponse);

    protected static async Task<TResponse?> ExecuteMaxQuery<TResponse>(
        IQueryable<TQueryable> query,
        Expression<Func<TQueryable, bool>>? predicate,
        Expression<Func<TQueryable, TResponse>> selector,
        CancellationToken cancellationToken
    ) => await (
        predicate is not null
            ? query.Where(predicate)
            : query
    ).MaxAsync(
        selector,
        cancellationToken
    );
}
