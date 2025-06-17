using Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;
using Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.WebApi.Extensions.Results;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class CategoriesController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IQueryHandler<GetAllCategoriesQuery, IEnumerable<Category>> mediator,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            new GetAllCategoriesQuery(),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }

    [HttpGet]
    [Route("{categoryName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> GetByNameAsync(
        [FromServices] IQueryHandler<GetCategoryByNameQuery, ResultOrError<Category, GetCategoryByNameFailure>> mediator,
        [FromRoute][Required] string categoryName,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
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
