namespace Api.TorMarket.Application.Repositories;

public record PaginatedResult<T>
{
    public required IEnumerable<T> Result { get; init; }
    public required uint PageSize { get; init; }
    public required uint PageIndex { get; init; }
    public required string SortColumn { get; init; } = null!;
    public required bool SortAscending { get; init; }
    public required uint TotalItemCount { get; init; }
    public required uint MaximumPageSize { get; init; }
    public required IEnumerable<string> SortableColumns { get; init; }
}
