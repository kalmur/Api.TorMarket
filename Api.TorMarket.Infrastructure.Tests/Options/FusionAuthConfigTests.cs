using Api.TorMarket.Infrastructure.Options;
using NUnit.Framework;
using Shouldly;

namespace Api.TorMarket.Infrastructure.Tests.Options;

[TestFixture]
internal class FusionAuthConfigTests : ConfigTestBase
{
    private const string ConfigSectionName = "FusionAuth";

    private const string AudienceKey = "Audience";
    private const string AuthenticationEndpointKey = "AuthenticationEndpoint";
    private const string AuthorityKey = "Authority";
    private const string ClientIdKey = "ClientId";
    private const string ClientSecretKey = "ClientSecret";
    private const string TenantIdKey = "TenantId";
    private const string GetUsersEndpointKey = "GetUsersEndpoint";
    private const string UsersQueryKey = "UsersQuery";
    private const string FieldsToIncludeKey = "FieldsToInclude";
    private const string IncludeFieldsKey = "IncludeFields";

    private static Dictionary<string, string?> ValidValues() => new()
    {
        { AudienceKey, "test" },
        { AuthenticationEndpointKey, "test" },
        { AuthorityKey, "test" },
        { ClientIdKey, "test" },
        { ClientSecretKey, "test" },
        { TenantIdKey, "test" },
        { GetUsersEndpointKey, "test" },
        { UsersQueryKey, "test" },
        { FieldsToIncludeKey, "test" },
        { IncludeFieldsKey, "test" }
    };

    [Test]
    public void GetFusionAuthConfigSection_WhenCalled_ReturnsIConfigurationSection()
    {
        var configuration = BuildConfiguration(
            ConfigSectionName,
            ValidValues()
        );

        // Act
        var fusionAuthConfigSection = FusionAuthConfig.GetFusionAuthConfigSection(configuration);

        // Assert
        foreach (var child in fusionAuthConfigSection.GetChildren())
        {
            child.Value.ShouldBe("test");
        }
    }

    [Test]
    public void LoadConfiguration_WhenCalledWithValidConfiguration_ReturnsFusionAuthConfig()
    {
        // Arrange
        var configuration = BuildConfiguration(
            ConfigSectionName,
            ValidValues()
        );

        // Act
        var fusionAuthConfig = FusionAuthConfig.LoadFromConfiguration(configuration);

        // Assert
        fusionAuthConfig.ShouldNotBeNull();
        fusionAuthConfig.Authority.ShouldBe("test");
        fusionAuthConfig.ClientId.ShouldBe("test");
        fusionAuthConfig.ClientSecret.ShouldBe("test");
        fusionAuthConfig.TenantId.ShouldBe("test");
    }

    [Test]
    public void LoadConfiguration_WhenCalledWithInvalidConfiguration_ThrowsInvalidOperationExceptionException()
    {
        // Arrange
        var configuration = BuildConfiguration(
            ConfigSectionName,
            []
        );

        // Act & Assert
        Should.Throw<InvalidOperationException>(
            () => FusionAuthConfig.LoadFromConfiguration(configuration)
        );
    }
}
