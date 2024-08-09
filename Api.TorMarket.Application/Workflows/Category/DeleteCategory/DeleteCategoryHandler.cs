using Api.TorMarket.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.TorMarket.Application.Workflows.Category.DeleteCategory;
public class DeleteCategoryHandler : INotificationHandler<DeleteCategoryNotification>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<DeleteCategoryHandler> _logger;

    public DeleteCategoryHandler(IApplicationDbContext context, ILogger<DeleteCategoryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task Handle(DeleteCategoryNotification notification, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _context.Category.SingleOrDefaultAsync(x => x.CategoryId == notification.CategoryId, cancellationToken);

        if (categoryToDelete is null)
        {
            _logger.LogInformation("Category with ID: '{id}' not found.", notification.CategoryId);
        }
        else
        {
            _context.Category.Remove(categoryToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Category with ID: '{id}' deleted.", notification.CategoryId);
        }
    }
}
