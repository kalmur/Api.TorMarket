using MediatR;

namespace Api.TorMarket.Application.Workflows.User.CreateUser;

public class CreateUserNotification : INotification
{
    public CreateUserNotification(int roleId, string externalId)
    {
        RoleId = roleId;
        ExternalId = externalId;
    }

    public int RoleId { get; set; }
    public string ExternalId { get; }
}
