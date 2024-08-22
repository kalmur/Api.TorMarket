using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Workflows.Review.CreateReview;
using Api.TorMarket.WebApi.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpResponse _httpResponse;

    public ReviewController(IMediator mediator, IHttpResponse httpResponse)
    {
        _mediator = mediator;
        _httpResponse = httpResponse;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
    {
        var notification = new CreateReviewNotification(dto.UserId, dto.ListingId, dto.Rating, dto.Comment);
        await _mediator.Publish(notification);
        return Created();
    }
}
