using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserModel))]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateProductRequestDto request,
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
    [Route("categories/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(CreateUserModel))]
    public async Task<IActionResult> GetProductCategoryByNameAsync(
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
