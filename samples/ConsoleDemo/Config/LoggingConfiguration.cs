using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleDemo.Config;

/// <summary>
/// Reconfigures <see cref="ILogger"/> and <see cref="ILogger{TCategoryName}"/> at runtime.
/// </summary>
public partial class LoggingConfiguration : ILoggingConfiguration
{
    private readonly string[] parentPath;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggingConfiguration"/> class.
    /// </summary>
    /// <param name="parentPath">Path to logging section.</param>
    public LoggingConfiguration(params string[] parentPath)
    {
        this.parentPath = parentPath ?? throw new ArgumentNullException(nameof(parentPath));

        if (parentPath.Any(string.IsNullOrWhiteSpace))
        {
            throw new ArgumentException("The segments of the parent path must be null nor empty.", nameof(parentPath));
        }
    }

    /// <inheritdoc/>
    public void SetConsoleFormatterOption(string name, bool value)
        => SetConsoleFormatterOption(name, value ? "true" : "false");

    /// <inheritdoc/>
    public void SetConsoleFormatterOption<TEnum>(string name, TEnum value)
        where TEnum : Enum
    {
        var enumName = GetNameForEnumValue(value);
        SetConsoleFormatterOption(name, enumName);
    }

    /// <inheritdoc/>
    public void SetConsoleFormatterOption(string name, string value)
    {
        var key = BuildConsoleFormatterOptionPath(name);
        SetValue(key, value);
    }

    /// <inheritdoc/>
    public void SetLogLevel(LogLevel logLevel, string category = "Default")
        => SetLogLevel(logLevel, provider: null, category);

    /// <inheritdoc/>
    public void SetLogLevel(LogLevel logLevel, string? provider, string category = "Default")
    {
        var key = BuildLogLevelPath(provider, category);
        var value = GetNameForEnumValue(logLevel);
        SetValue(key, value);
    }

    private static string GetNameForEnumValue<TEnum>(TEnum value)
        where TEnum : Enum
            => Enum.GetName(typeof(TEnum), value)
                ?? throw new ArgumentException("Invalid enum value", nameof(value));

    private string BuildConsoleFormatterOptionPath(string optionKey)
    {
        var segments = parentPath.ToList();
        segments.Add("Console");
        segments.Add("FormatterOptions");
        segments.Add(optionKey.Trim());
        return ConfigurationPath.Combine(segments);
    }

    private string BuildLogLevelPath(string? provider, string category)
    {
        var segments = parentPath.ToList();
        if (!string.IsNullOrWhiteSpace(provider))
        {
            segments.Add(provider.Trim());
        }

        segments.Add("LogLevel");
        segments.Add(category.Trim());
        return ConfigurationPath.Combine(segments);
    }

    private void SetValue(string key, string value)
    {
        foreach (var provider in providers)
        {
            provider.Set(key, value);
        }
    }
}
