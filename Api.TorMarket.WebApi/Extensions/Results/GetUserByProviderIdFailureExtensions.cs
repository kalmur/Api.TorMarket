using Api.TorMarket.WebApi.DTOs.Responses.Failures;
using System.ComponentModel;
using Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;
using static Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId.GetUserByProviderIdFailure;

namespace Api.TorMarket.WebApi.Extensions.Results;

internal static class GetUserByProviderIdFailureExtensions
{
    public static GetUserByProviderIdFailureResponseDto ToFailureResponseDto(
        this GetUserByProviderIdFailure failure
    ) => new()
    {
        Errors = failure.Errors.Select(
            error => error.ToErrorMessage()
        )
    };

    private static string ToErrorMessage(
        this ErrorType error
    ) => error switch
    {
        ErrorType.UserDoesNotExist => "User does not exist.",
        _ => throw new InvalidEnumArgumentException(nameof(ErrorType))
    };
}
