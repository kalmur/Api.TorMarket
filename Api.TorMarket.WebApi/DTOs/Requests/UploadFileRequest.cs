namespace Api.TorMarket.WebApi.DTOs.Requests;

public record UploadFileRequest
{
    public required string FilePath { get; init; }
    public required string FileName { get; init; }
}
