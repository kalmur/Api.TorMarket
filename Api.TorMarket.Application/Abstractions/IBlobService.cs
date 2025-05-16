using Azure.Storage.Blobs.Models;

namespace Api.TorMarket.Application.Abstractions;

public interface IBlobService
{
    Task<BlobInfo> GetBlobAsync(string blobName);
    Task<IEnumerable<string>> ListBlobsAsync();
    Task UploadFileBlobAsync(string filePath, string fileName);
    Task UploadContentBlobAsync(string content, string fileName);
    Task DeleteBlobAsync(string blobName);
}

