using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UploadFileForm
{
    [Required]
    public required IFormFile File { get; set; }
}