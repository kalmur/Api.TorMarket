using Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;
using Api.TorMarket.WebApi.DTOs.Responses;
using System.ComponentModel;

namespace Api.TorMarket.WebApi.Extensions.Results;

public static class CreateListingFailureExtensions
{
    public static CreateProductFailureResponseDto ToFailureResponseDto(
        this CreateProductFailure failure
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
