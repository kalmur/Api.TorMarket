namespace Api.TorMarket.Application.Errors;

public abstract class Error
{
    protected Error(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; set; }
}
