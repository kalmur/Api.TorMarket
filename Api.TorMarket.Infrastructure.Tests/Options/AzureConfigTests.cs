using Api.TorMarket.Infrastructure.Options;
using NUnit.Framework;
using Shouldly;

namespace Api.TorMarket.Infrastructure.Tests.Options;

[TestFixture]
internal class AzureConfigTests : ConfigTestBase
{
    private const string ConfigSectionName = "Azure";

    private const string AccessKey = "AccessKey";
    private const string ConnectionStringKey = "ConnectionString";
    private const string ListingsContainerNameKey = "ListingsContainerName";
    private const string StorageAccountNameKey = "StorageAccountName";

    [Test]
    public void GetAzureConfigSection_WhenCalled_ReturnsIConfigurationSection()
    {
        var configuration = BuildConfiguration(
            ConfigSectionName,
            new Dictionary<string, string?>
            {
                { AccessKey, "test" },
                { ConnectionStringKey, "test" },
                { ListingsContainerNameKey, "test" },
                { StorageAccountNameKey, "test" },
            }
        );

        // Act
        var azureConfigSection = AzureConfig.GetAzureConfig(configuration);

        // Assert
        foreach (var child in azureConfigSection.GetChildren())
        {
            child.Value.ShouldBe("test");
        }
    }

    [Test]
    public void LoadConfiguration_WhenCalledWithValidConfiguration_ReturnsAzureConfig()
    {
        // Arrange
        var configuration = BuildConfiguration(
            ConfigSectionName,
            new Dictionary<string, string?>
            {
                { AccessKey, "test" },
                { ConnectionStringKey, "test" },
                { ListingsContainerNameKey, "test" },
                { StorageAccountNameKey, "test" },
            }
        );

        // Act
        var azureConfig = AzureConfig.LoadFromConfiguration(configuration);

        // Assert
        azureConfig.ShouldNotBeNull();
        azureConfig.AccessKey.ShouldBe("test");
        azureConfig.ConnectionString.ShouldBe("test");
        azureConfig.ListingsContainerName.ShouldBe("test");
        azureConfig.StorageAccountName.ShouldBe("test");
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
