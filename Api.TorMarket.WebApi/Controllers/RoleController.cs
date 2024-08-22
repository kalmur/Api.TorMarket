using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Workflows.Role.CreateRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
    {
        var notification = new CreateRoleNotification(dto.Name, dto.Description);
        await _mediator.Publish(notification);
        return Created();
    }
}
