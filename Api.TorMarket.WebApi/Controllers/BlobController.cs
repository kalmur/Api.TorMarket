using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.WebApi.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlobController(
    IBlobService blobService
) : ControllerBase
{
    [HttpGet("{blobName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
    public async Task<IActionResult> GetByNameAsync(
        [Required] string blobName,
        CancellationToken cancellationToken
    )
    {
        var blob = await blobService.GetBlobAsync(
            blobName, 
            cancellationToken
        );

        return File(
            blob.Content, 
            blob.ContentType
        );
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
    public async Task<IActionResult> ListAsync(
        CancellationToken cancellationToken
    )
    {
        var blobs = await blobService.ListBlobsAsync(cancellationToken);

        return Ok(blobs);
    }

    [HttpPost("file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFileAsync(
        [FromBody][Required] UploadFileRequest request,
        CancellationToken cancellationToken
    )
    {
        await blobService.UploadFileBlobAsync(
            request.FilePath, 
            request.FileName,
            cancellationToken
        );

        return Ok();
    }

    [HttpPost("content")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadContentAsync(
        [FromBody][Required] UploadContentRequest request,
        CancellationToken cancellationToken
    )
    {
        await blobService.UploadContentBlobAsync(
            request.Content,
            request.FileName,
            cancellationToken
        );

        return Ok();
    }

    [HttpDelete("{blobName}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAsync(
        [Required] string blobName,
        CancellationToken cancellationToken
    )
    {
        await blobService.DeleteBlobAsync(
            blobName, 
            cancellationToken
        );

        return NoContent();
    }
}
