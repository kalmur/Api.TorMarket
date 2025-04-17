using System.ComponentModel;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;
using Api.TorMarket.WebApi.DTOs.Responses.Failures;
using static Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId.GetListingsByProviderIdFailure;

namespace Api.TorMarket.WebApi.Extensions.Results;

public static class GetListingsByProviderIdFailureExtensions
{
    public static GetListingsByProviderIdFailureResponseDto ToFailureResponseDto(
        this GetListingsByProviderIdFailure failure
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
        ErrorType.UserNotFound => "User not found",
        _ => throw new InvalidEnumArgumentException(nameof(ErrorType))
    };
}
