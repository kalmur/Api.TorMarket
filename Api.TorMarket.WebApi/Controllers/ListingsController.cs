using Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;
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
    [Route("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Listing>))]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(
            new GetAllListingsQuery(),
            cancellationToken
        );

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByCategoryNameAsync(
        [FromQuery] string category,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            category.ToListingsForCategory(),
            cancellationToken
        );

        return Ok(result);
    }

    [HttpGet]
    [Route("[name]")]
    public async Task<IActionResult> GeyByName(
       string name,
       CancellationToken cancellationToken
   )
    {
        var result = await mediator.Send(
            name.ToGetByNameQuery(),
            cancellationToken
        );

        return Ok(result);
    }

    //TODO - Move to a separate controller
    [HttpGet]
    [Route("categories/all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListingCategory>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAllListingCategoriesAsync(
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetAllCategoriesRequest(),
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
