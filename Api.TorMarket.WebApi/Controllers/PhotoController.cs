using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotoController
{
    private readonly IMediator _mediator;
    private readonly ILogger<PhotoController> _logger;

    public PhotoController(IMediator mediator, ILogger<PhotoController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
}
