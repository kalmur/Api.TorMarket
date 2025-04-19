using Api.TorMarket.Application.CQRS.Queries.Reviews.GetListingReviewByReviewId;
using Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ListingWithReviewAndCategory))]
    public async Task<IActionResult> CreateAsync(
        [FromBody] [Required] CreateListingReviewDto request,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            request.ToCommand(),
            cancellationToken
        );

        // Return Toresponse
        return resultOrError.IsError
            ? UnprocessableEntity(resultOrError.Error.ToFailureResponseDto())
            : CreatedAtAction(
                "GetByIdAsync",
                new { id = resultOrError.Result.ListingReviewId },
                resultOrError.Result
            );
    }

    [HttpGet]
    [Route("id/{reviewId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListingWithReviewAndCategory))]
    public async Task<IActionResult> GetByReviewIdAsync(
        [FromRoute] [Required] int reviewId,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetReviewByReviewIdQuery(reviewId),
            cancellationToken
        );

        return Ok(result);
    }

    [HttpGet]
    [Route("listing/{listingId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingReview>))]
    public async Task<IActionResult> GetByListingIdAsync(
        [FromRoute] [Required] int listingId,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetReviewsByListingIdQuery(listingId),
            cancellationToken
        );

        return Ok(result);
    }
}
