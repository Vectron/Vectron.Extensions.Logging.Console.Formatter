using Microsoft.Extensions.Configuration;

namespace ConsoleDemo.Config;

/// <summary>
/// Logging configuration source for changing logging configuration at runtime.
/// </summary>
public class LoggingConfigurationSource : IConfigurationSource
{
    private readonly IEnumerable<string> parentPath;
    private readonly ILoggingConfigurationProviderCollection providerCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggingConfigurationSource"/> class.
    /// </summary>
    /// <param name="providerCollection">
    /// Logging configuration provider collection that newly created providers are going to be added in.
    /// </param>
    /// <param name="parentPath">Path to logging section.</param>
    public LoggingConfigurationSource(ILoggingConfigurationProviderCollection providerCollection, params string[] parentPath)
    {
        this.providerCollection = providerCollection ?? throw new ArgumentNullException(nameof(providerCollection));
        this.parentPath = parentPath ?? throw new ArgumentNullException(nameof(parentPath));

        if (this.parentPath.Any(string.IsNullOrWhiteSpace))
        {
            throw new ArgumentException("The segments of the parent path must be null nor empty.", nameof(parentPath));
        }
    }

    /// <inheritdoc/>
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        var provider = new LoggingConfigurationProvider();
        providerCollection.Add(provider);
        return provider;
    }
}
