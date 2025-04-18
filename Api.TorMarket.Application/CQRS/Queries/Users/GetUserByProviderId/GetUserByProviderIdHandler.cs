using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public class GetUserByProviderIdHandler(IUserRepository repository) : IRequestHandler<GetUserByProviderIdQuery, User>
{
    public async Task<User> Handle(
        GetUserByProviderIdQuery request,
        CancellationToken cancellationToken
    ) => await repository.GetByProviderIdAsync(
        request.ProviderId, 
        cancellationToken
    );
}
