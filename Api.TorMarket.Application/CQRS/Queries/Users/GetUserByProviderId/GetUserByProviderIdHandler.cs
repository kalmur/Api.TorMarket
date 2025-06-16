using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed class GetUserByProviderIdHandler(
    IUserRepository repository
) : IQueryHandler<GetUserByProviderIdQuery, User>
{
    public async Task<User> HandleAsync(
        GetUserByProviderIdQuery request,
        CancellationToken cancellationToken
    ) => await repository.GetByProviderIdAsync(
        request.ProviderId, 
        cancellationToken
    );
}
