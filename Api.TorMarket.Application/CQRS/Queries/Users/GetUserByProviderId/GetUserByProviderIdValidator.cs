using Api.TorMarket.Application.Repositories.Interfaces;
using static Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId.GetUserByProviderIdFailure;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public class GetUserByProviderIdValidator : IValidator<GetUserByProviderIdQuery, GetUserByProviderIdFailure>
{
    private readonly IUserRepository _userRepository;

    public GetUserByProviderIdValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByProviderIdFailure?> ValidateAsync(
        GetUserByProviderIdQuery command,
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (await UserDoesNotExists(command.ProviderId, cancellationToken))
            errors.Add(ErrorType.UserDoesNotExist);

        if (errors.Count > 0)
        {
            return new GetUserByProviderIdFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> UserDoesNotExists(
        string providerId,
        CancellationToken cancellationToken
    ) => await _userRepository.GetByProviderIdAsync(
        providerId,
        cancellationToken
    ) is null;
}