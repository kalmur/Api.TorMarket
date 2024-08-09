using Api.TorMarket.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Category = Api.TorMarket.Domain.Entities.Category;

namespace Api.TorMarket.Application.Workflows.Category.CreateCategory;

public class CreateCategoryHandler : INotificationHandler<CreateCategoryNotification>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateCategoryHandler> _logger;

    public CreateCategoryHandler(IApplicationDbContext context, ILogger<CreateCategoryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(CreateCategoryNotification notification, CancellationToken cancellationToken)
    {
        var category = new Domain.Entities.Category
        {
            Name = notification.Name
        };

        _context.Category.Add(category);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Category: '{name}' created.", notification.Name);
    }
}
