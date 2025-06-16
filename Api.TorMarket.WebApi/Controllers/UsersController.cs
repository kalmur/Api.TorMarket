using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;
using Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;
using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;
using Api.TorMarket.WebApi.Extensions.Models;
using Api.TorMarket.WebApi.Extensions.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateAsync(
        [FromServices] ICommandHandler<CreateUserCommand, ResultOrError<User, CreateUserFailure>> handler,
        [FromBody][Required] CreateUserRequestDto createUserDto,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.HandleAsync(
            createUserDto.ToCommand(),
            cancellationToken
        );

        return result.IsError
            ? BadRequest(
                result.Error.ToFailureResponseDto()
            )
            : StatusCode(
                StatusCodes.Status201Created, 
                result.Result.ToResponseDto()
            );
    }

    [HttpGet]
    [Route("{providerId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    public async Task<IActionResult> GetByProviderIdAsync(
        [FromServices] IQueryHandler<GetUserByProviderIdQuery, User> mediator,
        [FromRoute][Required] string providerId,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            new GetUserByProviderIdQuery(providerId),
            cancellationToken
        );

        return Ok(
            result.ToResponseDto()
        );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IQueryHandler<GetAllUsersQuery, IEnumerable<User?>> mediator,
       CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            new GetAllUsersQuery(),
            cancellationToken
        );

        // Return dto
        return Ok(
            result
        );
    }
}
