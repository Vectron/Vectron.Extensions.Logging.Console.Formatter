using Microsoft.Extensions.Configuration;

namespace ConsoleDemo.Config;

/// <summary>
/// Changes logging configuration at runtime.
/// </summary>
public class LoggingConfigurationProvider : ConfigurationProvider
{
    /// <inheritdoc/>
    public override IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string? parentPath)
        => base.GetChildKeys(earlierKeys, parentPath);

    /// <inheritdoc/>
    public override void Set(string key, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            _ = Data.Remove(key);
            OnReload();
            return;
        }

        base.Set(key, value);
        OnReload();
    }

    /// <inheritdoc/>
    public override bool TryGet(string key, out string? value)
        => base.TryGet(key, out value);
}
