using System.ComponentModel;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.WebApi.DTOs.Responses.Failures;
using ErrorType = Api.TorMarket.Application.CQRS.Commands.Users.CreateUser.CreateUserFailure.ErrorType;

namespace Api.TorMarket.WebApi.Extensions.Results
{
    public static class CreateUserFailureExtensions
    {
        public static CreateUserFailureResponseDto ToFailureResponseDto(
            this CreateUserFailure failure
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
            ErrorType.InvalidProviderId => "Invalid provider id",
            ErrorType.UserAlreadyExists => "User already exists",
            _ => throw new InvalidEnumArgumentException(nameof(ErrorType))
        };
    }
}
