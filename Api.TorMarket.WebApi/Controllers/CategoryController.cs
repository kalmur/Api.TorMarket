using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Workflows.Category.Commands.Create;
using Api.TorMarket.Application.Workflows.Category.Commands.Delete;
using Api.TorMarket.Application.Workflows.Category.Commands.Update;
using Api.TorMarket.WebApi.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpResponse _httpResponse;

    public CategoryController(IMediator mediator, IHttpResponse httpResponse)
    {
        _mediator = mediator;
        _httpResponse = httpResponse;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCategoryDto))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        var request = new CreateCategoryNotification(dto.Name);
        await _mediator.Publish(request);
        return Created();
    }

    [HttpPut]
    [Route("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto dto)
    {
        var request = new UpdateCategoryRequest(dto.CategoryId, dto.Name);
        
        var response = await _mediator.Send(request);

        if (response.IsT1)
        {
            return response.AsT1.NotFoundError is not null 
                ? _httpResponse.NotFound("Category not found.") 
                : _httpResponse.UnprocessableEntity("Invalid input for category update.");
        }

        return Ok(response.AsT0.Name);
    }

    [HttpDelete]
    [Route("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
    {
        var request = new DeleteCategoryNotification(categoryId);
        await _mediator.Publish(request);
        return NoContent();
    }
}
