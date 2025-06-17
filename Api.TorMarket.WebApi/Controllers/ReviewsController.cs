using Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;
using Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;
using Api.TorMarket.WebApi.Extensions.Results;
using Api.TorMarket.Application.Abstractions.Mediator;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class ReviewsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ListingWithReviewAndCategory))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CreateAsync(
        [FromServices] ICommandHandler<CreateListingReviewCommand, ResultOrError<ListingReview, CreateListingReviewFailure>> mediator,

    [FromBody][Required] CreateListingReviewDto request,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.HandleAsync(
            request.ToCommand(),
            cancellationToken
        );

        return resultOrError.IsError
            ? UnprocessableEntity(
                resultOrError.Error.ToFailureResponseDto()
            )
            : Created();
        //: CreatedAtAction(
        //    "GetByIdAsync",
        //    new { id = resultOrError.Result.ListingReviewId },
        //    resultOrError.Result
        //);
    }

    [HttpGet]
    [Route("listing/{listingId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingReview>))]
    public async Task<IActionResult> GetByListingIdAsync(
        [FromServices] IQueryHandler<GetReviewsByListingIdQuery, IEnumerable<ListingReview>> mediator,
        [FromRoute][Required] int listingId,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            new GetReviewsByListingIdQuery(listingId),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListingWithReviewAndCategory))]
    public async Task<IActionResult> GetByListingAndUserIdAsync(
        [FromServices] IQueryHandler<GetReviewByUserAndListingIdQuery, ListingWithReviewAndCategory> mediator,
        [FromBody][Required] GetReviewByUserAndListingIdDto request,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            request.ToQuery(),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }
}
