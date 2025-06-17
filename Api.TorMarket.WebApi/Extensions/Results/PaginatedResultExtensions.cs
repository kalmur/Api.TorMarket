using Api.TorMarket.Application.Repositories;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Results
{
    public static class PaginatedResultExtensions
    {
        public static PaginatedResponseDto<TResponse> ToPaginatedResponseDto<T, TResponse>(
            this PaginatedResult<T> paginatedResult,
            Func<T, TResponse> convertResultToResponse
        ) where T : class where TResponse : class
            => new()
            {
                PageSize = paginatedResult.PageSize,
                PageIndex = paginatedResult.PageIndex,
                TotalItemCount = paginatedResult.TotalItemCount,
                MaximumPageSize = paginatedResult.MaximumPageSize,
                SortColumn = paginatedResult.SortColumn,
                SortAscending = paginatedResult.SortAscending,
                SortableColumns = paginatedResult.SortableColumns,
                Items = paginatedResult.Result.Select(convertResultToResponse)
            };

        public static PaginatedResponseDto<TResponse> ToPaginatedResponseDto<T, TResponse>(
            this PaginatedResult<T> paginatedResult,
            IEnumerable<TResponse> response
        ) where T : class where TResponse : class
            => new()
            {
                PageSize = paginatedResult.PageSize,
                PageIndex = paginatedResult.PageIndex,
                TotalItemCount = paginatedResult.TotalItemCount,
                MaximumPageSize = paginatedResult.MaximumPageSize,
                SortColumn = paginatedResult.SortColumn,
                SortAscending = paginatedResult.SortAscending,
                SortableColumns = paginatedResult.SortableColumns,
                Items = response
            };
    }
}
