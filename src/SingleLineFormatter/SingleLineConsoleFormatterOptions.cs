using Microsoft.Extensions.Logging.Console;

namespace Vectron.Extensions.Logging.Console.Formatter;

/// <summary>
/// Options for the single line console log formatter.
/// </summary>
public class SingleLineConsoleFormatterOptions : ConsoleFormatterOptions
{
    /// <summary>
    /// Gets or sets the colors to use.
    /// </summary>
    public ColorMode ColorMode
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether indicates if the whole line should be colored.
    /// </summary>
    public bool ColorWholeLine
    {
        get;
        set;
    }
}
