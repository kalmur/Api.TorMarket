using Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;
using Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class UsersController(
    ISender mediator
) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateAsync(
        [FromBody][Required] CreateUserRequestDto createUserDto,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            createUserDto.ToCommand(),
            cancellationToken
        );

        return resultOrError.IsError
            ? BadRequest(
                resultOrError.Error.ToFailureResponseDto()
            )
            : StatusCode(
                StatusCodes.Status201Created, 
                resultOrError.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [Route("{providerId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    public async Task<IActionResult> GetByProviderIdAsync(
        [FromRoute][Required] string providerId,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.Send(
            new GetUserByProviderIdQuery(providerId),
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    public async Task<IActionResult> GetAllAsync(
       CancellationToken cancellationToken
   )
    {
        var result = await mediator.Send(
            new GetAllUsersQuery(),
            cancellationToken
        );

        // Return dto
        return Ok(
            result
        );
    }
}
