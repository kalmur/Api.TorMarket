namespace Api.TorMarket.Application.Workflows.Users.Commands.CreateUser;

public record CreateUserFailure
{
    public required IEnumerable<ErrorType> Errors { get; init; }
}

public enum ErrorType
{
    InvalidProviderId,
    UserAlreadyExists
}
