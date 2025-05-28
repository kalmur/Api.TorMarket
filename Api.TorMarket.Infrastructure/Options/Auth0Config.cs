using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace Api.TorMarket.Infrastructure.Options;

public record Auth0Config
{
    public const string SectionName = "Auth0";

    [Required(AllowEmptyStrings = false)]
    public required string Domain { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ClientId { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ClientSecret { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string Connection { get; init; }

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
