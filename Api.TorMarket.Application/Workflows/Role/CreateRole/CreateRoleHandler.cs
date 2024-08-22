using Api.TorMarket.Application.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using ApiRole = Api.TorMarket.Domain.Entities.Role;

namespace Api.TorMarket.Application.Workflows.Role.CreateRole;

public class CreateRoleHandler : INotificationHandler<CreateRoleNotification>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateRoleHandler> _logger;

    public CreateRoleHandler(IApplicationDbContext context, ILogger<CreateRoleHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(CreateRoleNotification notification, CancellationToken cancellationToken)
    {
        var role = new ApiRole
        {
            Name = notification.Name,
            Description = notification.Description
        };

        _context.Role.Add(role);

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Role: {roleName}, with ID: {roleId}.", role.Name, role.RoleId);
    }
}