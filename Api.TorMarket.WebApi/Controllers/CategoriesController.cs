using Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;
using Api.TorMarket.Application.Mediator;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CategoriesController(
    ISender mediator
) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IQueryHandler<GetAllCategoriesQuery, IEnumerable<Category>> handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.HandleAsync(
            new GetAllCategoriesQuery(),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }

    [HttpGet]
    [Route("{categoryName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> GetByNameAsync(
        [FromRoute][Required] string categoryName,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetCategoryByNameQuery(categoryName),
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
