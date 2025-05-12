using Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ListingDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CreateAsync(
        [FromBody][Required] CreateListingRequestDto request,
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
            : CreatedAtAction(
                nameof(GetByListingIdAsync),
                new { listingId = resultOrError.Result.ListingId },
                resultOrError.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithDetailsDto>))]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new GetAllListingsQuery(),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }

    [HttpGet]
    [Route("id/{listingId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithDetailsDto>))]
    public async Task<IActionResult> GetByListingIdAsync(
        [FromRoute][Required] int listingId, 
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetListingByIdQuery(listingId),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }

    [HttpGet]
    [Route("name/{listingName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingDto>))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> SearchByListingNameAsync(
        [FromRoute][Required] string listingName,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            new GetListingsByNameQuery(listingName),
            cancellationToken
        );

        return resultOrError.IsError
            ? UnprocessableEntity(
                resultOrError.Error.ToFailureResponseDto()
            )
            : Ok(
                resultOrError.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [Route("user/{providerId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithCategory>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetByProviderId(
        [FromRoute][Required] string providerId,
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
            : Ok(
                resultOrError.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [Route("category/{categoryName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithCategory>))]
    public async Task<IActionResult> GetByCategoryNameAsync(
        [FromRoute][Required] string categoryName,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetListingsByCategoryNameQuery(categoryName),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }
}
