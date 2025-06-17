using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed class GetUserByProviderIdHandler(
    IValidator<GetUserByProviderIdQuery, GetUserByProviderIdFailure> validator,
    IUserRepository repository
) : IQueryHandler<GetUserByProviderIdQuery, ResultOrError<User, GetUserByProviderIdFailure>>
{
    public async Task<ResultOrError<User, GetUserByProviderIdFailure>> HandleAsync(
        GetUserByProviderIdQuery query,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await repository.GetByProviderIdAsync(
            query.ProviderId,
            cancellationToken
        );
    }
}
