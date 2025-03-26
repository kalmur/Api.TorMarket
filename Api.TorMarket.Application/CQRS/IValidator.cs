namespace Api.TorMarket.Application.CQRS;

internal interface IValidator<TCommand, TFailure>
{
    Task<TFailure?> ValidateAsync(
        TCommand command,
        CancellationToken cancellationToken
    );
}
