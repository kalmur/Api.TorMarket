namespace Api.TorMarket.Application.Interfaces.Services;

public interface IPasswordValidator
{
    bool ValidatePassword(string password);
}
