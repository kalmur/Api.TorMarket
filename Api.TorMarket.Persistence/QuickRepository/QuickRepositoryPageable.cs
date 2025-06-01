using System.Linq.Expressions;
using Api.TorMarket.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.QuickRepository;

internal abstract class QuickRepositoryPageable<TQueryable> : QuickRepository<TQueryable> where TQueryable : class
{
    protected abstract uint MaximumPageSize { get; }
    protected abstract IReadOnlyDictionary<string, IOrderBy> OrderFunctions { get; }
    protected abstract IOrderBy DefaultOrderFunction { get; }

    public IEnumerable<string> SortableColumnNames => OrderFunctions.Keys;


    protected async Task<PaginatedResult<TResponse>> ExecutePaginatedQueryAsync<TResponse>(
        IQueryable<TQueryable> query,
        Expression<Func<TQueryable, bool>>? predicate,
        Func<TQueryable, TResponse> convertToResponse,
        PaginatedRequest pagination,
        CancellationToken cancellationToken
    )
    {
        if (predicate is not null)
            query = query.Where(predicate);

        var maximumPageSize = Math.Max(
            MaximumPageSize,
            1
        );

        var totalItemsCount = (uint)await query
            .CountAsync(cancellationToken);

        pagination.Validate(
            maximumPageSize,
            totalItemsCount
        );

        var orderBy = OrderFunctions.TryGetValue(
            pagination.SortColumn,
            out IOrderBy? orderFunction
        ) ? orderFunction : DefaultOrderFunction;

        pagination.SortColumn = OrderFunctions.Single(
            orderFunction => orderFunction.Value == orderBy
        ).Key;

        var results = await (
            pagination.SortAscending
                ? query
                    .OrderBy(orderBy)
                    .ThenBy(DefaultOrderFunction)
                : query
                    .OrderByDescending(orderBy)
                    .ThenBy(DefaultOrderFunction)
        )
            .Skip((int)pagination.ItemsToSkip)
            .Take((int)pagination.PageSize)
            .ToListAsync(cancellationToken);

        return pagination.ToPaginatedResult(
            results.Select(convertToResponse),
            totalItemsCount,
            maximumPageSize,
            SortableColumnNames
        );
    }

    protected class OrderBy<Field>(
        Expression<Func<TQueryable, Field>> TypedExpression
    ) : IOrderBy
    {
        public dynamic Expression => TypedExpression;
    }
}
