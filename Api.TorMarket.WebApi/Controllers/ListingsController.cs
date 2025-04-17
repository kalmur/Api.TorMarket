using Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Listing))]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateListingRequestDto request,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            request.ToCommand(),
            cancellationToken
        );

        return resultOrError.IsError
            ? UnprocessableEntity(
                resultOrError.Error.ToFailureResponseDto()
            )
            : StatusCode(
                StatusCodes.Status201Created,
                resultOrError.Result.ToResponseDto()
            );

            //TODO - GeyById endpoint

            //: CreatedAtAction(
            //    "GetById",
            //    new { id = resultOrError.Result.ListingId },
            //    resultOrError.Result.ToResponseDto()
            //);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithCategory>))]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new GetAllListingsQuery(),
            cancellationToken
        );

        return Ok(result);
    }

    [HttpGet]
    [Route("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithCategory>))]
    public async Task<IActionResult> GeyByNameAsync(
        [FromRoute] string name,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            name.ToGetByNameQuery(),
            cancellationToken
        );

        return resultOrError.IsError
            ? UnprocessableEntity(
                resultOrError.Error.ToFailureResponseDto()
            )
            : Ok(resultOrError.Result);
    }

    [HttpGet]
    [Route("user/{providerId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithCategory>))]
    public async Task<IActionResult> GetByProviderId(
        [FromRoute] string providerId,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            new GetListingsByProviderIdQuery(providerId),
            cancellationToken
        );

        return resultOrError.IsError
            ? NotFound(
                resultOrError.Error.ToFailureResponseDto()
            )
            : Ok(resultOrError.Result);
    }

    [HttpGet]
    [Route("category/{category}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithCategory>))]
    public async Task<IActionResult> GetByCategoryNameAsync(
        [FromRoute] string category,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            category.ToGetByCategoryNameQuery(),
            cancellationToken
        );

        return Ok(result);
    }
}
