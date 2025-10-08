using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Application.Abstractions.Azure;

public interface ISearchService
{
    Task<IEnumerable<SearchDocument>> SearchAsync(string query, CancellationToken cancellationToken);
}
