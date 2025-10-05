using Api.TorMarket.Application.Abstractions.Azure;
using Api.TorMarket.Domain.Models.External;
using Azure.Search.Documents;

namespace Api.TorMarket.Infrastructure.Services.Azure;

internal class SearchService : ISearchService
{
    private readonly SearchClient _searchClient;

    public SearchService(SearchClient searchClient)
    {
        _searchClient = searchClient;
    }

    public async Task<IEnumerable<SearchDocument>> SearchAsync(string query)
    {
        var options = new SearchOptions { Size = 10 };

        var results = await _searchClient.SearchAsync<SearchDocument>(query, options);

        return results.Value.GetResults().Select(r => r.Document);
    }
}
