using Api.TorMarket.Application.Abstractions;
using IdentityModel;

namespace Api.TorMarket.Application.Services;

public class PasswordGenerator : IPasswordGenerator
{
    public string GetNewPassword()
    {
        return Base64Url.Encode(CryptoRandom.CreateRandomKey(20));
    }
}
