using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;
using Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;
using Api.TorMarket.WebApi.Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.WebApi.Extensions.Results;
using Api.TorMarket.Application.Abstractions.Mediator;
using Microsoft.AspNetCore.Authorization;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateAsync(
        [FromServices] ICommandHandler<CreateUserCommand, ResultOrError<User, CreateUserFailure>> mediator,
        [FromBody][Required] CreateUserRequestDto createUserDto,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.HandleAsync(
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserProfileDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetByProviderIdAsync(
        [FromServices] IQueryHandler<GetUserByProviderIdQuery, ResultOrError<UserProfile, GetUserByProviderIdFailure>> mediator,
        [FromRoute][Required] string providerId,
        CancellationToken cancellationToken
    )
    {
        var resultOrError = await mediator.HandleAsync(
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
    [Authorize("admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserProfileDto>))]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IQueryHandler<GetAllUsersQuery, IEnumerable<UserProfile>> mediator,
       CancellationToken cancellationToken
    )
    {
        var result = await mediator.HandleAsync(
            new GetAllUsersQuery(),
            cancellationToken
        );

        return Ok(
            result.Select(
                profile => profile.ToResponseDto()
            )
        );
    }
}
