using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text;
using Api.TorMarket.Application.Abstractions;
using Microsoft.Extensions.Options;
using Api.TorMarket.Infrastructure.Options;
using BlobInfo = Api.TorMarket.Domain.Models.External.BlobInfo;

namespace Api.TorMarket.Infrastructure.Services;

public class BlobService : IBlobService
{
    private readonly AzureConfig options;
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _containerClient;

    public BlobService(IOptions<AzureConfig> config)
    {
        options = config?.Value
            ?? throw new ArgumentNullException(nameof(config));

        _blobServiceClient = new BlobServiceClient(
            options.ConnectionString
        );

        _containerClient = _blobServiceClient.GetBlobContainerClient(
            options.ListingsContainerName
        );
    }

    public async Task<BlobInfo> GetBlobAsync(
        string blobName, 
        CancellationToken cancellationToken
    )
    {
        var blobClient = _containerClient.GetBlobClient(blobName);

        var downloadInfo = await blobClient.DownloadAsync(cancellationToken);

        return new BlobInfo(
            downloadInfo.Value.Content,
            downloadInfo.Value.ContentType
        );
    }

    public async Task<IEnumerable<string>> ListBlobsAsync(CancellationToken cancellationToken)
    {
        var items = new List<string>();

        await foreach (var blobItem in _containerClient.GetBlobsAsync(
                           cancellationToken: cancellationToken))
        {
            items.Add(blobItem.Name);
        }

        return items;
    }

    public async Task UploadFileBlobAsync(
        string filePath, 
        string fileName,
        CancellationToken cancellationToken
    )
    {
        var blobClient = _containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(
            filePath,
            new BlobHttpHeaders
            {
                ContentType = "text/plain"
            },
            cancellationToken: cancellationToken
        );
    }

    public async Task UploadContentBlobAsync(
        string content, 
        string fileName,
        CancellationToken cancellationToken
    )
    {
        var blobClient = _containerClient.GetBlobClient(fileName);

        var bytes = Encoding.UTF8.GetBytes(content);

        await using var memoryStream = new MemoryStream(bytes);

        await blobClient.UploadAsync(
            memoryStream,
            new BlobHttpHeaders
            {
                ContentType = "text/plain"
            },
            cancellationToken: cancellationToken
        );
    }

    public async Task DeleteBlobAsync(
        string blobName,
        CancellationToken cancellationToken
    )
    {
        var blobClient = _containerClient.GetBlobClient(blobName);

        await blobClient.DeleteIfExistsAsync(
            cancellationToken: cancellationToken
        );
    }

    public async Task<string> UploadFileFromStreamAsync(
    Stream fileStream,
    string fileName,
    string contentType,
    CancellationToken cancellationToken
)
    {
        if (fileStream == null || fileStream.Length == 0)
            throw new ArgumentException("File stream cannot be null or empty", nameof(fileStream));

        var shortGuid = Guid.NewGuid().ToString("N").Substring(0, 15);

        var uniqueFileName = $"{shortGuid}_{fileName}";

        var blobClient = _containerClient.GetBlobClient(uniqueFileName);

        await blobClient.UploadAsync(
            fileStream,
            new BlobHttpHeaders
            {
                ContentType = contentType
            },
            cancellationToken: cancellationToken
        );

        return GenerateBlobUrl(uniqueFileName);
    }

    public string GenerateBlobUrl(string blobName)
    {
        var blobUri = new Uri($"https://{options.StorageAccountName}.blob.core.windows.net/{options.ListingsContainerName}/{blobName}");
        return blobUri.ToString();
    }
}
