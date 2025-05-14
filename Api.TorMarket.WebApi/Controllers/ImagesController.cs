using Api.TorMarket.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController(
    IAzureBlobService blobStorageService
) : ControllerBase
{
    private const string ContainerName = "images";

   
}
