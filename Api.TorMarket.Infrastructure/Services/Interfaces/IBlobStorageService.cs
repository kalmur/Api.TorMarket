namespace Api.TorMarket.Infrastructure.Services.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadFileAsync(string fileName, Stream fileStream, CancellationToken cancellationToken);
}

