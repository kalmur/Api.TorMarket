using Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;
using Api.TorMarket.WebApi.DTOs.Responses.Failures;
using System.ComponentModel;
using static Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName.GetCategoryByNameFailure;

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
