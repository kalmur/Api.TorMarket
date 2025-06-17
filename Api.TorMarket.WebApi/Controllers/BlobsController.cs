using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Blob;
using Api.TorMarket.WebApi.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class BlobsController(
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
    public async Task<IActionResult> GetAllAsync(
        CancellationToken cancellationToken
    )
    {
        var blobs = await blobService.ListBlobsAsync(cancellationToken);

        return Ok(blobs);
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFileFromStreamAsync(
        [FromForm] UploadFileForm form,
        CancellationToken cancellationToken
    )
    {
        if (form.File == null || form.File.Length == 0)
            return BadRequest("File is required");

        await using var stream = form.File.OpenReadStream();

        var blobUrl = await blobService.UploadFileFromStreamAsync(
            stream,
            form.File.FileName,
            form.File.ContentType,
            cancellationToken
        );

        return Ok(
            new { url = blobUrl }
        );
    }

    [HttpPost("file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFileAsync(
        [FromBody][Required] UploadFileRequest request,
        CancellationToken cancellationToken
    )
    {
        await blobService.UploadFileAsync(
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
        await blobService.UploadContentAsync(
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
