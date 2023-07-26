using Microsoft.Extensions.Logging;

namespace ConsoleDemo;

/// <summary>
/// Class for writing test messages to the logger.
/// </summary>
internal static class LogTest
{
    /// <summary>
    /// Write test messages to the logger.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    public static void WriteLogs(ILogger logger)
    {
        WriteLevelMessages(logger);

        Console.WriteLine("With scopes");
        using (logger.BeginScope("Logging scope"))
        {
            using (logger.BeginScope("Nested scope"))
            {
                WriteLevelMessages(logger);
            }
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1848:Use the LoggerMessage delegates", Justification = "Not performance critical")]
    private static void WriteLevelMessages(ILogger logger)
    {
        logger.LogTrace("This is a trace message");
        logger.LogDebug("This is a debug Message");
        logger.LogInformation("This is a information Message");
        logger.LogWarning("This is a warning Message");
        logger.LogError("This is a error Message");
        logger.LogCritical("This is a critical Message");
        logger.LogError(new InvalidOperationException("Something went wrong."), "Error with exception");
        Console.WriteLine();
    }
}
