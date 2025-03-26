namespace Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

public record CreateUserFailure
{
    public required IEnumerable<ErrorType> Errors { get; init; }
}

public enum ErrorType
{
    InvalidProviderId,
    UserAlreadyExists
}
