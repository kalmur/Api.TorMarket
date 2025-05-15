using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Infrastructure.Services.Interfaces;
using Api.TorMarket.WebApi.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlobController(
    IBlobService azureBlobService
) : ControllerBase
{
    [HttpGet("{blobName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
    public async Task<IActionResult> GetBlob(
        [Required] string blobName
    )
    {
        var blob = await azureBlobService.GetBlobAsync(blobName);

        return File(
            blob.Content, 
            blob.ContentType
        );
    }

    [HttpGet("list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
    public async Task<IActionResult> ListBlobs()
    {
        var blobs = await azureBlobService.ListBlobsAsync();

        return Ok(blobs);
    }

    [HttpPost("uploadfile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFileBlob(
        [FromBody][Required] UploadFileRequest request
    )
    {
        await azureBlobService.UploadFileBlobAsync(
            request.FilePath, 
            request.FileName    
        );

        return Ok();
    }

    [HttpPost("uploadcontent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFileBlob(
        [FromBody][Required] UploadContentRequest request
    )
    {
        await azureBlobService.UploadContentBlobAsync(
            request.Content,
            request.FileName
        );

        return Ok();
    }

    [HttpDelete("{blobName}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteBlob(
        [Required] string blobName
    )
    {
        await azureBlobService.DeleteBlobAsync(blobName);

        return NoContent();
    }
}
