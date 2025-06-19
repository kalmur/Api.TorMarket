using Api.TorMarket.Application.Repositories.Interfaces;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

using static GetListingsByProviderIdFailure;

public sealed class GetListingsByProviderIdValidator : IValidator<GetListingsByProviderIdQuery, GetListingsByProviderIdFailure>
{
    private readonly IUserRepository _repository;

    public GetListingsByProviderIdValidator(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetListingsByProviderIdFailure?> ValidateAsync(
        GetListingsByProviderIdQuery query,
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (await UserNotFound(query.ProviderId, cancellationToken))
            errors.Add(ErrorType.UserNotFound);

        if (errors.Count > 0)
        {
            return new GetListingsByProviderIdFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> UserNotFound(
        string providerId,
        CancellationToken cancellationToken
    ) =>
    (
        await _repository.GetByProviderIdAsync(
            providerId,
            cancellationToken
        )
    ) is null;
}