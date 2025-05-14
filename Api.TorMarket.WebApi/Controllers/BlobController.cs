using Api.TorMarket.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlobController(
    IAzureBlobService azureBlobService
) : ControllerBase
{
    [HttpGet("{blobName}")]
    public async Task<IActionResult> GetBlob(string blobName)
    {
        var blob = await azureBlobService.GetBlobAsync(blobName);

        return File(
            blob.Content, 
            blob.ContentType
        );
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListBlobs()
    {
        var blobs = await azureBlobService.ListBlobsAsync();

        return Ok(blobs);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFileBlob(IFormFile file)
    {
        if (file.Length == 0)
            return BadRequest("File is empty");

        using var stream = file.OpenReadStream();

        await azureBlobService.UploadFileBlobAsync(
            //TODO - Work on this
            stream.ToString(), 
            file.FileName
        );

        return Ok();
    }

    [HttpDelete("{blobName}")]
    public async Task<IActionResult> DeleteBlob(string blobName)
    {
        await azureBlobService.DeleteBlobAsync(blobName);

        return NoContent();
    }
}
