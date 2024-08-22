using MediatR;

namespace Api.TorMarket.Application.Workflows.Role.CreateRole;

public class CreateRoleNotification : INotification
{
    public CreateRoleNotification(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }
}