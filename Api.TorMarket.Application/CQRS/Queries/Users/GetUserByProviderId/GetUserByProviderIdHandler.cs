using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed class GetUserByProviderIdHandler : IQueryHandler<GetUserByProviderIdQuery, ResultOrError<User, GetUserByProviderIdFailure>>
{
    private readonly IValidator<GetUserByProviderIdQuery, GetUserByProviderIdFailure> _validator;
    private readonly IUserRepository _repository;

    public GetUserByProviderIdHandler(
        IValidator<GetUserByProviderIdQuery, GetUserByProviderIdFailure> validator,
        IUserRepository repository
    )
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<ResultOrError<User, GetUserByProviderIdFailure>> HandleAsync(
        GetUserByProviderIdQuery query,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await _validator.ValidateAsync(
            query,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await _repository.GetByProviderIdAsync(
            query.ProviderId,
            cancellationToken
        );
    }
}
