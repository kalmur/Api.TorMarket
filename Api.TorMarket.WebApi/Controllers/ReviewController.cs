using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController
{
    private readonly IMediator _mediator;
    private readonly ILogger<ReviewController> _logger;

    public ReviewController(IMediator mediator, ILogger<ReviewController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
}
