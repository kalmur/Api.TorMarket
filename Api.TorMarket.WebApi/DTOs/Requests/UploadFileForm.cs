using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public record UploadFileForm
{
    [Required]
    public IFormFile File { get; set; }
}