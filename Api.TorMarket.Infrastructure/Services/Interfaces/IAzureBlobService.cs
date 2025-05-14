using Api.TorMarket.Infrastructure.Models;

namespace Api.TorMarket.Infrastructure.Services.Interfaces;

public interface IAzureBlobService
{
    Task<BlobInfo> GetBlobAsync(string blobName);
    Task<IEnumerable<string>> ListBlobsAsync();
    Task UploadFileBlobAsync(string filePath, string fileName);
    Task UploadContentBlobAsync(string content, string fileName);
    Task DeleteBlobAsync(string blobName);
}

