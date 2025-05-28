using Microsoft.Extensions.Configuration;

namespace Api.TorMarket.Infrastructure.Tests.Options;

internal abstract class ConfigTestBase
{
    protected static IConfiguration BuildConfiguration(
        string sectionName,
        IEnumerable<KeyValuePair<string, string?>> settings
    ) =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(
                settings.Select(
                    setting => new KeyValuePair<string, string?>(
                        $"{sectionName}:{setting.Key}", setting.Value
                    )
                )
            )
            .Build();
}