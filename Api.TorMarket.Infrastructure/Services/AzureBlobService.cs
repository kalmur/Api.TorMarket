using Api.TorMarket.Infrastructure.Services.Interfaces;
using Azure.Storage;
using Azure.Storage.Blobs;

namespace Api.TorMarket.Infrastructure.Services;

public class AzureBlobService : IAzureBlobService
{
    private const string _storageAccount = "tormarketblob";
    private const string _accessKey = "vtoTWrxTclCDGUCX3q1IYvuMPOnCc3pMIlQpKRG0P9rmdA6tamP7IrEZY7XjfNeWwvU+rzvL7V/N+AStBvqBtw==";

    private readonly BlobServiceClient _blobServiceClient;

    public AzureBlobService()
    {
        var credentials = new StorageSharedKeyCredential(_storageAccount, _accessKey);
        var blobUri = $"https://{_storageAccount}.blob.core.windows.net";

        _blobServiceClient = new(
            new Uri(blobUri),
            credentials
        );
    }

    public async Task<IEnumerable<Uri>> UploadFilesAsync()
    {
        var blobUris = new List<Uri>();
        string filePath = "";
        var blobContainer = _blobServiceClient.GetBlobContainerClient("images");

        var blob = blobContainer.GetBlobClient($"{filePath}");

        await blob.UploadAsync(filePath, true);
        blobUris.Add(blob.Uri);

        return blobUris;
    }
}
