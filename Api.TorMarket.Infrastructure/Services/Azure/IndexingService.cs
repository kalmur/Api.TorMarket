using Azure.Search.Documents.Indexes;
using Azure.Search.Documents;
using Azure;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.Application.Abstractions.Azure;

namespace Api.TorMarket.Infrastructure.Services.Azure;

internal class IndexingService : IIndexingService
{
    private readonly SearchIndexClient _indexClient;
    private readonly SearchClient _searchClient;

    public IndexingService(string endpoint, string apiKey, string indexName)
    {
        var credential = new AzureKeyCredential(apiKey);

        _indexClient = new SearchIndexClient(new Uri(endpoint), credential);
        _searchClient = new SearchClient(new Uri(endpoint), indexName, credential);
    }

    public async Task UploadDataAsync(
        IEnumerable<SearchDocument> data, 
        CancellationToken cancellationToken
    )
    {
        await _searchClient.UploadDocumentsAsync(
            data,
            cancellationToken: cancellationToken
        );
    }
}
