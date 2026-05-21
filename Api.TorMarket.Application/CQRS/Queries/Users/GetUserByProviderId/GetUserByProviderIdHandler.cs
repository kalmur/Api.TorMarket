using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed class GetUserByProviderIdHandler : IQueryHandler<GetUserByProviderIdQuery, ResultOrError<UserProfile, GetUserByProviderIdFailure>>
{
    private readonly IValidator<GetUserByProviderIdQuery, GetUserByProviderIdFailure> _validator;
    private readonly IUserRepository _repository;
    private readonly IIdentityProviderService _identityProviderService;

    public GetUserByProviderIdHandler(
        IValidator<GetUserByProviderIdQuery, GetUserByProviderIdFailure> validator,
        IUserRepository repository,
        IIdentityProviderService identityProviderService
    )
    {
        _validator = validator;
        _repository = repository;
        _identityProviderService = identityProviderService;
    }

    public async Task<ResultOrError<UserProfile, GetUserByProviderIdFailure>> HandleAsync(
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

        var user = await _repository.GetByProviderIdAsync(
            query.ProviderId,
            cancellationToken
        );

        if (user is null)
        {
            return new GetUserByProviderIdFailure
            {
                Errors = new[] { GetUserByProviderIdFailure.ErrorType.UserDoesNotExist }
            };
        }

        var identityProfiles = await _identityProviderService.GetUsersInformationAsync(
            new[] { user.ProviderId },
            cancellationToken
        );

        return new UserProfile
        {
            User = user,
            IdentityProfile = identityProfiles.FirstOrDefault(
                p => string.Equals(p.ExternalProviderId, user.ProviderId, StringComparison.Ordinal)
            )
        };
    }
}
