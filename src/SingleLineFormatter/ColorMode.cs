namespace Vectron.Extensions.Logging.Console.Formatter;

/// <summary>
/// The color mode to use.
/// </summary>
public enum ColorMode
{
    /// <summary>
    /// Microsoft.Extensions.Logging.Console.
    /// </summary>
    MEL,

    /// <summary>
    /// NLog colored console.
    /// </summary>
    NLog,

    /// <summary>
    /// Serilog ANSI console.
    /// </summary>
    Serilog,
}
