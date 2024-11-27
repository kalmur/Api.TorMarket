using Api.TorMarket.Domain.Repositories;

namespace Api.TorMarket.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}