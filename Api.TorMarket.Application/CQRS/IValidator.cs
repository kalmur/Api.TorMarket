namespace Api.TorMarket.Application.CQRS;

public interface IValidator<TCommand, TFailure>
{
    Task<TFailure?> ValidateAsync(
        TCommand command,
        CancellationToken cancellationToken
    );
}
