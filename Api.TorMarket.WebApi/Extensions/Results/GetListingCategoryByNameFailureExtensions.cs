using Api.TorMarket.WebApi.DTOs.Responses;
using System.ComponentModel;
using Api.TorMarket.Application.Workflows.Listings.Queries.GetCategoryByName;

namespace Api.TorMarket.WebApi.Extensions.Results;

public static class GetListingCategoryByNameFailureExtensions
{
    public static GetProductCategoryByNameFailureResponseDto ToFailureResponseDto(
        this GetCategoryByNameFailure failure
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
        ErrorType.CategoryDoesNotExist => "Category does not exist.",
        ErrorType.CategoryNameIsNotValid => "Invalid category name.",
        _ => throw new InvalidEnumArgumentException(nameof(ErrorType))
    };
}