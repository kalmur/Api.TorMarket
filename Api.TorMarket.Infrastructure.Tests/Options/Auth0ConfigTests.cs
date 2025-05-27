using Api.TorMarket.Infrastructure.Options;
using NUnit.Framework;
using Shouldly;

namespace Api.TorMarket.Infrastructure.Tests.Options;

[TestFixture]
internal class Auth0ConfigTests : ConfigTestBase
{
    private const string ConfigSectionName = "Auth0";

    private const string DomainKey = "Domain";
    private const string ClientIdKey = "ClientId";
    private const string ClientSecretKey = "ClientSecret";
    private const string ConnectionKey = "Connection";

    [Test]
    public void GetAuth0ConfigSection_WhenCalled_ReturnsIConfigurationSection()
    {
        var configuration = BuildConfiguration(
            ConfigSectionName,
            new Dictionary<string, string?>
            {
                { DomainKey, "test" },
                { ClientIdKey, "test" },
                { ClientSecretKey, "test" },
                { ConnectionKey, "test" }
            }
        );

        // Act
        var auth0ConfigSection = Auth0Config.GetAuth0ConfigSection(configuration);

        // Assert
        foreach (var child in auth0ConfigSection.GetChildren())
        {
            child.Value.ShouldBe("test");
        }
    }

    [Test]
    public void LoadConfiguration_WhenCalledWithValidConfiguration_ReturnsAuth0Config()
    {
        // Arrange
        var configuration = BuildConfiguration(
            ConfigSectionName,
            new Dictionary<string, string?>
            {
                { DomainKey, "test" },
                { ClientIdKey, "test" },
                { ClientSecretKey, "test" },
                { ConnectionKey, "test" }
            }
        );

        // Act
        var auth0Config = Auth0Config.LoadFromConfiguration(configuration);

        // Assert
        auth0Config.ShouldNotBeNull();
        auth0Config.Domain.ShouldBe("test");
        auth0Config.ClientId.ShouldBe("test");
        auth0Config.ClientSecret.ShouldBe("test");
        auth0Config.Connection.ShouldBe("test");
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
            () => AzureConfig.LoadFromConfiguration(configuration)
        );
    }
}
