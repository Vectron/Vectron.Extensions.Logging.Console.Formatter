using Microsoft.Extensions.Logging;

namespace ConsoleDemo.Config;

/// <summary>
/// Reconfigures <see cref="ILogger"/> and <see cref="ILogger{TCategoryName}"/> at runtime.
/// </summary>
public interface ILoggingConfiguration
{
    /// <summary>
    /// Set a FormatterOption for the console formatter.
    /// </summary>
    /// <param name="name">The name of the option.</param>
    /// <param name="value">The new value.</param>
    void SetConsoleFormatterOption(string name, bool value);

    /// <summary>
    /// Set a FormatterOption for the console formatter.
    /// </summary>
    /// <typeparam name="TEnum">The type of enum.</typeparam>
    /// <param name="name">The name of the option.</param>
    /// <param name="value">The new value.</param>
    void SetConsoleFormatterOption<TEnum>(string name, TEnum value)
        where TEnum : Enum;

    /// <summary>
    /// Set a FormatterOption for the console formatter.
    /// </summary>
    /// <param name="name">The name of the option.</param>
    /// <param name="value">The new value.</param>
    void SetConsoleFormatterOption(string name, string value);

    /// <summary>
    /// Set the <paramref name="logLevel"/> for all providers.
    /// </summary>
    /// <param name="logLevel">Log level.</param>
    /// <param name="category">Logging category.</param>
    void SetLogLevel(LogLevel logLevel, string category = "Default");

    /// <summary>
    /// Set the <paramref name="logLevel"/> for the given providers.
    /// </summary>
    /// <param name="logLevel">Log level.</param>
    /// <param name="provider">Logging provider.</param>
    /// <param name="category">Logging category.</param>
    void SetLogLevel(LogLevel logLevel, string? provider, string category = "Default");
}
