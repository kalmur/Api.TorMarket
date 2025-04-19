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
[Route("api/[controller]")]
public class UsersController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
    public async Task<IActionResult> CreateAsync(
        [FromBody] [Required] CreateUserRequestDto createUserDto,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            createUserDto.ToCommand(),
            cancellationToken
        );

        return result.IsError
            ? BadRequest(result.Error.ToFailureResponseDto())
            : StatusCode(
                StatusCodes.Status201Created, 
                result.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [Route("{providerId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    public async Task<IActionResult> GetByProviderIdAsync(
        [FromRoute] [Required] string providerId,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.Send(
            new GetUserByProviderIdQuery(providerId),
            cancellationToken
        );

        return Ok(result);
    }
}
