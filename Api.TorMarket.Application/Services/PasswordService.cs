using Api.TorMarket.Application.Services.Interfaces;

namespace Api.TorMarket.Application.Services;

public class PasswordService : IPasswordService
{
    private readonly IPasswordGenerator _passwordGenerator;
    private readonly IPasswordValidator _passwordValidator;

    public PasswordService(IPasswordGenerator passwordGenerator, IPasswordValidator passwordValidator)
    {
        _passwordGenerator = passwordGenerator;
        _passwordValidator = passwordValidator;
    }

    public string GetNewPassword()
    {
        string password;

        do
        {
            password = _passwordGenerator.GetNewPassword();
        } while (!_passwordValidator.ValidatePassword(password));

        return password;
    }
}
