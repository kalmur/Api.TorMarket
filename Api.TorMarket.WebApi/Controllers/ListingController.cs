using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController
{
    private readonly IMediator _mediator;
    private readonly ILogger<ListingController> _logger;

    public ListingController(IMediator mediator, ILogger<ListingController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
}