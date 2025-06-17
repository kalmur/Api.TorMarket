using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;
using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class ListingsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ListingDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CreateAsync(
        [FromServices] ICommandHandler<CreateListingCommand, ResultOrError<Listing, CreateListingFailure>> mediator,
        [FromBody][Required] CreateListingRequestDto request,
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
            : CreatedAtAction(
                nameof(GetByIdAsync),
                new { listingId = resultOrError.Result.ListingId },
                resultOrError.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithDetailsDto>))]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IQueryHandler<GetAllListingsQuery, IEnumerable<ListingWithDetails>> mediator,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
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
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] IQueryHandler<GetListingByIdQuery, ListingWithDetails> mediator,
        [FromRoute][Required] int listingId, 
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
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
    public async Task<IActionResult> GetByName(
        [FromServices] IQueryHandler<GetListingsByNameQuery, ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>> mediator,
        [FromRoute][Required] string listingName,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.HandleAsync(
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithDetailsDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetByProviderId(
        [FromServices] IQueryHandler<GetListingsByProviderIdQuery, ResultOrError<IEnumerable<ListingWithDetails>, GetListingsByProviderIdFailure>> mediator,
        [FromRoute][Required] string providerId,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.HandleAsync(
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingWithDetailsDto>))]
    public async Task<IActionResult> GetByCategoryNameAsync(
        [FromServices] IQueryHandler<GetListingsByCategoryNameQuery, IEnumerable<ListingWithDetails>> mediator,
        [FromRoute][Required] string categoryName,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            new GetListingsByCategoryNameQuery(categoryName),
            cancellationToken
        );

        return Ok(
            result!.ToResponseDto()
        );
    }

    [HttpPut]
    [Route("blob/{listingId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateBlobUrlsAsync(
        [FromServices] ICommandHandler<UpdateListingBlobUrlsCommand, Listing> mediator,
        [FromRoute][Required] int listingId,
        [FromBody] UpdateBlobUrlRequestDto request,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.HandleAsync(
            request.ToCommand(listingId),
            cancellationToken
        );

        return Ok(resultOrError);
    }
}
