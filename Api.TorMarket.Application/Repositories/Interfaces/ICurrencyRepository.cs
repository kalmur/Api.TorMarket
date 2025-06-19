using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Repositories.Interfaces;

public interface ICurrencyRepository
{
    Task<Currency?> GetByCodeAync(
        string codeName,
        CancellationToken cancellationToken
    );
}
