using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Workflows.Category.CreateCategory;
using Api.TorMarket.Application.Workflows.Category.DeleteCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        var request = new CreateCategoryNotification(dto.Name);
        await _mediator.Publish(request);
        return NoContent();
    }

    [HttpDelete]
    [Route("{categoryId}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
    {
        var request = new DeleteCategoryNotification(categoryId);
        await _mediator.Publish(request);
        return NoContent();
    }
}
