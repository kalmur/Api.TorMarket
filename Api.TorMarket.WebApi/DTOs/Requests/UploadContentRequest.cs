namespace Api.TorMarket.WebApi.DTOs.Requests;

public record UploadContentRequest
{
    public required string Content { get; init; }
    public required string FileName { get; init; }
}