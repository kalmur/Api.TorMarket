using Api.TorMarket.Application.Results.Errors;

namespace Api.TorMarket.Domain.Results.Errors;

public class DatabaseError : Error
{
    public DatabaseError(string errorMessage)
        :base(ErrorType.Database)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; }
}
