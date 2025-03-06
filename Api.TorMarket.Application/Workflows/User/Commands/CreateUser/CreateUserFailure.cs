namespace Api.TorMarket.Application.Workflows.User.Commands.CreateUser;

public record CreateUserFailure
{
    public IEnumerable<ErrorType> Errors { get; init; }
}

public enum ErrorType
{
    InvalidProviderId,
    UserAlreadyExists
}
