using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text;
using Api.TorMarket.Application.Abstractions;
using BlobInfo = Api.TorMarket.Infrastructure.Models.BlobInfo;

namespace Api.TorMarket.Infrastructure.Services;

public class BlobService : IBlobService
{
    private const string ContainerName = "images";

    private static readonly BlobHttpHeaders DefaultTextHeaders = new()
    {
        ContentType = "text/plain"
    };

    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _containerClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient 
            ?? throw new ArgumentNullException(nameof(blobServiceClient)
        );
        _containerClient = _blobServiceClient.GetBlobContainerClient(
            ContainerName
        );
    }

    public async Task<BlobInfo> GetBlobAsync(string blobName)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);

        var downloadInfo = await blobClient.DownloadAsync();

        return new BlobInfo(
            downloadInfo.Value.Content,
            downloadInfo.Value.ContentType
        );
    }

    public async Task<IEnumerable<string>> ListBlobsAsync()
    {
        var items = new List<string>();

        await foreach (var blobItem in _containerClient.GetBlobsAsync())
        {
            items.Add(blobItem.Name);
        }

        return items;
    }

    public async Task UploadFileBlobAsync(
        string filePath, 
        string fileName
    )
    {
        var blobClient = _containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(
            filePath,
            DefaultTextHeaders
        );
    }

    public async Task UploadContentBlobAsync(
        string content, 
        string fileName
    )
    {
        var blobClient = _containerClient.GetBlobClient(fileName);

        var bytes = Encoding.UTF8.GetBytes(content);

        await using var memoryStream = new MemoryStream(bytes);

        await blobClient.UploadAsync(
            memoryStream,
            DefaultTextHeaders
        );
    }

    public async Task DeleteBlobAsync(string blobName)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);

        await blobClient.DeleteIfExistsAsync();
    }
}
