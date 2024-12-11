namespace Api.TorMarket.Domain.Results.Errors;

public enum ErrorType
{
    Api,
    Database,
    NotFound,
    RequestValidation
}

public abstract class Error
{
    protected Error(ErrorType type)
    {
        Type = type;
    }

    public ErrorType Type { get; }
}
