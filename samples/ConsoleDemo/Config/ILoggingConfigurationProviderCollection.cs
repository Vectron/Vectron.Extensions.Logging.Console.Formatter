using Microsoft.Extensions.Configuration;

namespace ConsoleDemo.Config;

/// <summary>
/// A collection of <see cref="IConfigurationProvider"/>.
/// </summary>
public interface ILoggingConfigurationProviderCollection : ICollection<IConfigurationProvider>
{
}
