namespace Api.TorMarket.Application.Workflows;

public interface IValidator<TCommand, TFailure>
{
    Task<TFailure> ValidateAsync(
        TCommand command, 
        CancellationToken cancellationToken
    );
}