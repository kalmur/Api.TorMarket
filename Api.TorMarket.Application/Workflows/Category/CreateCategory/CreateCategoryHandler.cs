using Api.TorMarket.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using ApiCategory = Api.TorMarket.Domain.Entities.Category;

namespace Api.TorMarket.Application.Workflows.Category.CreateCategory;

public class CreateCategoryHandler : INotificationHandler<CreateCategoryNotification>
{
    private readonly ICategoryRepository _repository;
    private readonly ILogger<CreateCategoryHandler> _logger;

    public CreateCategoryHandler(ICategoryRepository repository, ILogger<CreateCategoryHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task Handle(CreateCategoryNotification notification, CancellationToken cancellationToken)
    {
        var category = new ApiCategory
        {
            Name = notification.Name
        };

        await _repository.AddCategoryAsync(category, cancellationToken);

        _logger.LogInformation("Category: '{name}' created.", notification.Name);
    }
}
