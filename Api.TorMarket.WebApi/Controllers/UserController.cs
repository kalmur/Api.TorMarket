using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateUserRequestDto createUserDto,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            createUserDto.ToCommand(),
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
    }
}
