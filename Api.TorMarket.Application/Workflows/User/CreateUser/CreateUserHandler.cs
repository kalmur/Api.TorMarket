using Api.TorMarket.Application.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using ApiUser = Api.TorMarket.Domain.Entities.User;

namespace Api.TorMarket.Application.Workflows.User.CreateUser;

public class CreateUserHandler : INotificationHandler<CreateUserNotification>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateUserHandler> _logger;

    public CreateUserHandler(IApplicationDbContext context, ILogger<CreateUserHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(CreateUserNotification notification, CancellationToken cancellationToken)
    {
        var user = new ApiUser
        {
            RoleId = notification.RoleId,
            ExternalId = notification.ExternalId
        };

        _context.User.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("User {externalProviderId} added to DB", notification.ExternalId);
    }
}
