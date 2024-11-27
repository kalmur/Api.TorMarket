using Api.TorMarket.Application.Errors;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using OneOf;

namespace Api.TorMarket.Application.Workflows.Category.Commands.Update;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, OneOf<UpdateCategoryResponse, UpdateCategoryError>>
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateCategoryHandler> _logger;

    public UpdateCategoryHandler
    (
        ICategoryRepository repository,
        IUnitOfWork unitOfWork,
        ILogger<UpdateCategoryHandler> logger
    )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<OneOf<UpdateCategoryResponse, UpdateCategoryError>> Handle(UpdateCategoryRequest request, CancellationToken ct)
    {
        var category = await _repository.GetCategoryById(request.CategoryId, ct);

        if (category is null)
        {
            _logger.LogInformation("Category with ID: '{id}' not found", request.CategoryId);

            var notFound = new NotFound("Category not found", request.CategoryId);
            return new UpdateCategoryError(notFound);
        }

        if(category.Name == request.Name)

        {
            _logger.LogInformation("Category with Name: '{name}' already exists", request.Name);

            var unprocessableEntity = new UnprocessableEntity("test");
            return new UpdateCategoryError(null, unprocessableEntity);
        }

        category.Name = request.Name;
        await _unitOfWork.SaveChangesAsync(ct);

        _logger.LogInformation("Category with ID: '{id}' updated to: '{updatedName}'", request.CategoryId, request.Name);

        return new UpdateCategoryResponse(request.Name);
    }
}
