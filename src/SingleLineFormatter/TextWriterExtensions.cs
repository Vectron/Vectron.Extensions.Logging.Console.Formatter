namespace Vectron.Extensions.Logging.Console.Formatter;

/// <summary>
/// Extension methods for writing colored messages.
/// </summary>
internal static class TextWriterExtensions
{
    private static readonly string ResetColor = "\u001b[39m\u001b[22m\u001b[49m";

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="color">The ANSI color string.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="colorWholeLine">Indicates if the whole line is colored.</param>
    public static void WriteColored(this TextWriter textWriter, string color, string text, bool colorWholeLine)
    {
        if (!colorWholeLine && !string.IsNullOrEmpty(color))
        {
            textWriter.Write(color);
        }

        textWriter.Write(text);

        if (!colorWholeLine && !string.IsNullOrEmpty(color))
        {
            textWriter.WriteResetColor();
        }
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="color">The ANSI color string.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="colorWholeLine">Indicates if the whole line is colored.</param>
    public static void WriteColored(this TextWriter textWriter, string color, object? text, bool colorWholeLine)
    {
        if (!colorWholeLine && !string.IsNullOrEmpty(color))
        {
            textWriter.Write(color);
        }

        textWriter.Write(text);

        if (!colorWholeLine && !string.IsNullOrEmpty(color))
        {
            textWriter.WriteResetColor();
        }
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="color">The ANSI color string.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="colorWholeLine">Indicates if the whole line is colored.</param>
    public static void WriteColored(this TextWriter textWriter, string color, Span<char> text, bool colorWholeLine)
    {
        if (!colorWholeLine && !string.IsNullOrEmpty(color))
        {
            textWriter.Write(color);
        }

        textWriter.Write(text);

        if (!colorWholeLine && !string.IsNullOrEmpty(color))
        {
            textWriter.WriteResetColor();
        }
    }

    /// <summary>
    /// Write the ANSI reset color.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    public static void WriteResetColor(this TextWriter textWriter)
        => textWriter.Write(ResetColor);
}
