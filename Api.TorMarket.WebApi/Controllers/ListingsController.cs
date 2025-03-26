using System.Collections.Immutable;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.External;
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
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserModel))]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateListingRequestDto request,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            request.ToCommand(),
            cancellationToken
        );

        return result.IsError
            ? UnprocessableEntity(
                result.Error.ToFailureResponseDto()
            )
            : StatusCode(
                StatusCodes.Status201Created, 
                result.Result.ToResponseDto()
            );

        // CreatedAtAction maybe
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImmutableArray<Listing>))]
    public async Task<IActionResult> GetAllAsync(
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetAllListingsQuery(),
            cancellationToken
        );

        return Ok(result);
    }

    [HttpGet]
    [Route("categories/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(ListingCategory))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetListingCategoryByNameAsync(
        string name,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            name.ToQuery(),
            cancellationToken
        );

        return result.IsError
            ? BadRequest(
                result.Error.ToFailureResponseDto()
            )
            : Ok(
                result.Result.ToResponseDto()
            );
    }
}
