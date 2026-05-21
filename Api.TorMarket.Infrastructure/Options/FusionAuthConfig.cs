using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace Api.TorMarket.Infrastructure.Options;

public class FusionAuthConfig
{
    public const string SectionName = "FusionAuth";

    /// <summary>
    ///     The expected audience (typically the FusionAuth Application/Client Id)
    ///     used to validate inbound JWTs and as the audience for client_credentials.
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string Audience { get; set; }

    /// <summary>
    ///     The OAuth2 token endpoint, e.g. "/oauth2/token".
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string AuthenticationEndpoint { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ClientId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string ClientSecret { get; set; }

    /// <summary>
    ///     The FusionAuth tenant id used to scope user searches and token issuance.
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string TenantId { get; init; }

    /// <summary>
    ///     The base URL of the FusionAuth instance, e.g. "https://fusionauth.example.com".
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string Authority { get; init; }

    /// <summary>
    ///     The FusionAuth user search endpoint, e.g. "/api/user/search".
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string GetUsersEndpoint { get; init; }

    /// <summary>
    ///     The query template used when retrieving users. Supports
    ///     {Query}, {FieldsToInclude}, {IncludeFields} placeholders.
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public required string UsersQuery { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string FieldsToInclude { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string IncludeFields { get; init; }

    internal static IConfigurationSection GetFusionAuthConfigSection(
        IConfiguration configuration
    ) => configuration.GetSection(SectionName);

    internal static FusionAuthConfig LoadFromConfiguration(
        IConfiguration configuration
    )
    {
        var fusionAuthConfig = GetFusionAuthConfigSection(configuration)
            .Get<FusionAuthConfig>()
                ?? throw new InvalidOperationException(
                    $"Missing {SectionName} configuration section"
                );

        Validator.ValidateObject(
            fusionAuthConfig,
            new ValidationContext(fusionAuthConfig),
            validateAllProperties: true
        );

        return fusionAuthConfig;
    }
}
