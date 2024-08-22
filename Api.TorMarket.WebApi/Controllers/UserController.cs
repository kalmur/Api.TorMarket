using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Workflows.User.CreateUser;
using Api.TorMarket.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Api.TorMarket.Application.Abstractions;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAuth0Service _auth0Service;

    public UserController(IMediator mediator, IAuth0Service auth0Service)
    {
        _mediator = mediator;
        _auth0Service = auth0Service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserDto))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
    {
        var result = await GetAuthUserOrCreate(dto);

        return result.Succeeded
            ? StatusCode((int)result.StatusCode, result.Message)
            : Ok(result);
    }

    [HttpPut]
    [Route("{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAuth0User(
        string externalProviderId,
        [FromBody] UpdateUserDto user
    )
    {
        var result = await _auth0Service.UpdateUserAsync(externalProviderId, new UpdateUserDto
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
        });

        return !result.Succeeded
            ? StatusCode((int)result.StatusCode, result.Message)
            : Ok(result);
    }

    [HttpGet]
    [Route("{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuth0User(string externalProviderId)
    {
        var result = await _auth0Service.GetUserAsync(externalProviderId);

        return !result.Succeeded
            ? StatusCode((int)result.StatusCode, result.Message)
            : Ok(result);
    }

    private async Task<ApiResult<UserModel>> GetAuthUserOrCreate(CreateUserDto user)
    {
        ApiResult<UserModel> identityProviderUser;

        var result = await _auth0Service.GetUserByEmail(user.Email).ConfigureAwait(false);

        if (result.Succeeded && result.Item.Any())
        {
            if (result.Item.Count > 1)
            {
                return new ApiResult<UserModel>
                {
                    Message = $"Multiple users found with the email address {user.Email}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Succeeded = false
                };
            }

            identityProviderUser = new ApiResult<UserModel>
            {
                StatusCode = result.StatusCode,
                Succeeded = true,
                Item = result.Item.First()
            };

            await UpdateUser(identityProviderUser);
        }
        else
        {
            var createUserResult = await _auth0Service.CreateUserAsync(user).ConfigureAwait(false);
            if (!createUserResult.Succeeded) return createUserResult;

            identityProviderUser = createUserResult;
            await UpdateUser(identityProviderUser);

            var externalProviderId = identityProviderUser.Item.ProviderSubjectId;

            await _mediator.Publish(new CreateUserNotification(user.RoleId, externalProviderId));
        }

        return identityProviderUser;
    }

    private async Task UpdateUser(ApiResult<UserModel> identityProviderUser)
    {
        var updateUser = new UpdateUserDto
        {
            FirstName = identityProviderUser.Item.FirstName,
            LastName = identityProviderUser.Item.LastName,
            Email = identityProviderUser.Item.Email,
            PhoneNumber = identityProviderUser.Item.PhoneNumber
        };

        await _auth0Service.UpdateUserAsync(identityProviderUser.Item.ProviderSubjectId, updateUser)
            .ConfigureAwait(false);
    }
}
