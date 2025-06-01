namespace Api.TorMarket.Application.Repositories;

public class PaginatedRequest
{
    public required uint PageSize { get; set; }
    public required uint PageIndex { get; set; }
    public required string SortColumn { get; set; }
    public required bool SortAscending { get; set; }

    public uint ItemsToSkip => PageSize * PageIndex;

    public void Validate(
        uint maximumPageSize,
        uint totalItemsCount
    )
    {
        PageSize = Math.Min(
            Math.Max(
                PageSize,
                1
            ),
            Math.Max(
                maximumPageSize,
                1
            )
        );

        PageIndex = Math.Min(
            PageIndex,
            (totalItemsCount - 1) / PageSize
        );
    }

    public PaginatedResult<T> ToPaginatedResult<T>(
        IEnumerable<T> result,
        uint totalItemsCount,
        uint maxiumumPageSize,
        IEnumerable<string> sortableColumns
    ) => new()
    {
        Result = result,
        PageSize = PageSize,
        PageIndex = PageIndex,
        SortColumn = SortColumn,
        SortAscending = SortAscending,
        TotalItemCount = totalItemsCount,
        MaximumPageSize = maxiumumPageSize,
        SortableColumns = sortableColumns
    };
}
