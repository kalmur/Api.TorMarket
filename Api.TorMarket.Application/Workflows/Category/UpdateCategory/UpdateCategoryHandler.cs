using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Results.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.TorMarket.Application.Workflows.Category.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<UpdateCategoryHandler> _logger;

    public UpdateCategoryHandler(IApplicationDbContext context, ILogger<UpdateCategoryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await _context.Category.SingleOrDefaultAsync(
            x => x.CategoryId == request.CategoryId, 
            cancellationToken
        );

        if (categoryToUpdate is null)
        {
            _logger.LogInformation("Category with ID: '{id}' not found", request.CategoryId);
            return new UpdateCategoryResponse
            (
                error: new NotFoundError($"{request.CategoryId}", "Listing")
            );
        }
        else
        {
            categoryToUpdate.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Category with ID: '{id}' updated to: '{updatedName}'", 
                request.CategoryId,
                request.Name
            );

            return new UpdateCategoryResponse();
        }
    }
}
