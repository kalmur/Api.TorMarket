using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Workflows.Listing.CreateListing;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private readonly IMediator _mediator;

    public ListingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateListingResponse))]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingDto dto)
    {
        var request = dto.ToRequest();

        var response = await _mediator.Send(request);

        return Created("api/listing", response.ListingId);
    }
}