using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
using Api.TorMarket.WebApi.DTOs.Responses;
using System.ComponentModel;
using static Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName.GetListingsByNameFailure;


namespace Api.TorMarket.WebApi.Extensions.Results;

public static class GetListingByNameFailureExtensions
{
    public static GetListingByNameFailureResponseDto ToFailureResponseDto(
        this GetListingsByNameFailure failure
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
        ErrorType.InvalidName => "Invalid name",
        ErrorType.NotFound => "Listing not found",
        _ => throw new InvalidEnumArgumentException(nameof(ErrorType))
    };
}
