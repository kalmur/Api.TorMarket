namespace Api.TorMarket.Application.Mediator;

public interface ICommandHandler<in TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    Task<TResult> HandleAsync(
        TCommand command, 
        CancellationToken cancellationToken
    );
}