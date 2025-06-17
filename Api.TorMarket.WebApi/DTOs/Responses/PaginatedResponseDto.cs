namespace Api.TorMarket.WebApi.DTOs.Responses;

public record PaginatedResponseDto<T> where T : class
{
    public required uint PageSize { get; init; }
    public required uint PageIndex { get; init; }
    public required uint TotalItemCount { get; init; }
    public required uint MaximumPageSize { get; init; }
    public required string SortColumn { get; init; }
    public required bool SortAscending { get; init; }
    public required IEnumerable<string> SortableColumns { get; init; }
    public required IEnumerable<T> Items { get; init; }
}
