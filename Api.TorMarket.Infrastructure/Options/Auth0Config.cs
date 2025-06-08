using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace Api.TorMarket.Infrastructure.Options;

public class Auth0Config
{
    public const string SectionName = "Auth0";

    [Required(AllowEmptyStrings = false)]
    public required string Audience { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string AuthenticationEndpoint { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ClientId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string ClientSecret { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string Connection { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string Domain { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string GetUsersEndpoint { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string UsersQuery { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string FieldsToInclude { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string IncludeFields { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string SearchEngine { get; init; }

    internal static IConfigurationSection GetAuth0ConfigSection(
        IConfiguration configuration
    ) => configuration.GetSection(SectionName);

    internal static Auth0Config LoadFromConfiguration(
        IConfiguration configuration
    )
    {
        var auth0Config = GetAuth0ConfigSection(configuration)
            .Get<Auth0Config>() 
                ?? throw new InvalidOperationException(
                    $"Missing {SectionName} configuration section"
                );

        Validator.ValidateObject(
            auth0Config, 
            new ValidationContext(auth0Config), 
            validateAllProperties: true
        );

        return auth0Config;
    }
}
