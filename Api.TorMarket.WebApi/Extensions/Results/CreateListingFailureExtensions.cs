using System.ComponentModel;
using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.WebApi.DTOs.Responses.Failures;
using static Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing.CreateListingFailure;

namespace Api.TorMarket.WebApi.Extensions.Results;

public static class CreateListingFailureExtensions
{
    public static CreateListingFailureResponseDto ToFailureResponseDto(
        this CreateListingFailure failure
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
        ErrorType.InvalidCategoryId => "Invalid category id",
        ErrorType.InvalidPrice => "Invalid price",
        ErrorType.UserDoesNotExist => "User does not exist",
        _ => throw new InvalidEnumArgumentException(nameof(ErrorType))
    };
}
