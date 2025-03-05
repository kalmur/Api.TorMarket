using Microsoft.AspNetCore.Mvc;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.Application.Interfaces.Services;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IAuth0Service _auth0Service;

    public UserController(IAuth0Service auth0Service)
    {
        _auth0Service = auth0Service;
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

    [HttpPut]
    [Route("{externalProviderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAuth0User(
        string externalProviderId,
        [FromBody] UpdateUserModel user
    )
    {
        var result = await _auth0Service.UpdateUserAsync(externalProviderId, new UpdateUserModel
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
}
