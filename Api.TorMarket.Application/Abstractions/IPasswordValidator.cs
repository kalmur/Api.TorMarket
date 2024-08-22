namespace Api.TorMarket.Application.Abstractions;

public interface IPasswordValidator
{
    bool ValidatePassword(string password);
}
