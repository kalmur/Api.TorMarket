using Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ISender mediator) : ControllerBase
{
    [HttpGet]
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
    [Route("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListingCategory))]
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
