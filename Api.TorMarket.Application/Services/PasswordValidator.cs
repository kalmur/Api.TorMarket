using Api.TorMarket.Application.Abstractions;

namespace Api.TorMarket.Application.Services;

public class PasswordValidator : IPasswordValidator
{
    private const int RequiredLength = 8;
    private const int MatchedRulesRequirement = 3;

    private readonly char[] _specialChars = new[]{' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.',
        '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};


    public bool ValidatePassword(string password)
    {
        if (password.Length < RequiredLength) return false;

        var inputChars = password.ToCharArray();

        var matchedRuleCount = 0;

        if (inputChars.Any(x => int.TryParse(x.ToString(), out _))) matchedRuleCount++;
        if (inputChars.Any(x => x >= 'A' && x <= 'Z')) matchedRuleCount++;
        if (inputChars.Any(x => x >= 'a' && x <= 'z')) matchedRuleCount++;
        if (inputChars.Any(x => _specialChars.Contains(x))) matchedRuleCount++;

        return matchedRuleCount >= MatchedRulesRequirement;
    }
}
