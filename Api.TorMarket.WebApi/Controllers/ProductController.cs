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
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserModel))]
    public async Task<IActionResult> CreateAsync(
        [FromQuery] CreateProductRequestDto request
    )
    {
        var result = await _mediator.Send(
            request.ToCommand()
        );

        return result.IsError
            ? UnprocessableEntity(
                result.Error.ToCreateProductFailureResponseDto()
            )
            : StatusCode(
                StatusCodes.Status201Created, 
                result.Result.ToCreateProductResponseDto()
            );

        // CreatedAtAction maybe
    }
}
