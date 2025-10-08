using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Application.Abstractions.Azure;

public interface IIndexingService
{
    Task UploadDataAsync(IEnumerable<SearchDocument> data, CancellationToken cancellationToken);
}
