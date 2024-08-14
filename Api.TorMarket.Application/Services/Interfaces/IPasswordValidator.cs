namespace Api.TorMarket.Application.Services.Interfaces;

public interface IPasswordValidator
{
    bool ValidatePassword(string password);
}
