using Api.TorMarket.Infrastructure.Services.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Api.TorMarket.Infrastructure.Services;

internal class BlobStorageService : IBlobStorageService
{
    private const string ContainerName = "images";
    private const string ConnectionString = "";

    private readonly BlobContainerClient _blobContainerClient;

    public BlobStorageService(BlobServiceClient blobServiceClient)
    {
        _blobContainerClient = new BlobContainerClient(
            ConnectionString,
            ContainerName
        );
    }

    public async Task<string> UploadFileAsync(string fileName, Stream fileStream, CancellationToken cancellationToken)
    {
        await _blobContainerClient.CreateIfNotExistsAsync(
            PublicAccessType.Blob, 
            cancellationToken: cancellationToken
        );

        var blobClient = _blobContainerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(
            fileStream, 
            overwrite: true, 
            cancellationToken
        );

        return blobClient.Uri.ToString();
    }
}
