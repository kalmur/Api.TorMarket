using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Application.Abstractions;

public interface IBlobService
{
    Task<BlobInfo> GetBlobAsync(
        string blobName, 
        CancellationToken cancellationToken
    );

    Task<IEnumerable<string>> ListBlobsAsync(
        CancellationToken cancellationToken
    );

    Task UploadFileAsync(
        string filePath, 
        string fileName, 
        CancellationToken cancellationToken
    );

    Task UploadContentAsync(
        string content, 
        string fileName, 
        CancellationToken cancellationToken
    );

    Task DeleteBlobAsync(
        string blobName, 
        CancellationToken cancellationToken
    );

    Task<string> UploadFileFromStreamAsync(
        Stream fileStream,
        string fileName,
        string contentType,
        CancellationToken cancellationToken
    );

    string GenerateBlobUrl(
        string blobName
    );
}

