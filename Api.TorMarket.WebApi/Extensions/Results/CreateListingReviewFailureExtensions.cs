using Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;
using Api.TorMarket.WebApi.DTOs.Responses.Failures;
using System.ComponentModel;
using static Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview.CreateListingReviewFailure;

namespace Api.TorMarket.WebApi.Extensions.Results;

public static class CreateListingReviewFailureExtensions
{
    public static CreateListingReviewFailureResponseDto ToFailureResponseDto(
       this CreateListingReviewFailure failure
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
        ErrorType.ListingNotFound => "Listing not found.",
        ErrorType.UserNotFound => "User not found.",
        ErrorType.ReviewAlreadyExists => "Review already exists for this listing.",
        ErrorType.InvalidValue => "Invalid rating. Rating must be between 1 and 5.",
        ErrorType.InvalidComment => "Invalid comment.",
        _ => throw new InvalidEnumArgumentException(nameof(error), (int)error, typeof(ErrorType))
    };
}
