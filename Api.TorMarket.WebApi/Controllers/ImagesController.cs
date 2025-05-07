using Api.TorMarket.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController(
    IBlobStorageService blobStorageService
) : ControllerBase
{
    private const string ContainerName = "images";

    [HttpPost]
    public async Task<IActionResult> UploadAsync(
        CancellationToken cancellationToken
    )
    {
        var form = await Request.ReadFormAsync(cancellationToken);

        var tasks = form.Files.Select(async file =>
        {
            await using var stream = file.OpenReadStream();

            return await blobStorageService.UploadFileAsync(
                file.FileName, 
                stream, 
                cancellationToken
            );
        });

        var fileUrls = await Task.WhenAll(tasks);

        return Ok(fileUrls);
    }
}
