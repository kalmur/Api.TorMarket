using MediatR;

namespace Api.TorMarket.Application.Workflows.User.CreateUser;

public class CreateUserNotification : INotification
{
    public CreateUserNotification(string externalId)
    {
        ExternalId = externalId;
    }

    public string ExternalId { get; }
}
