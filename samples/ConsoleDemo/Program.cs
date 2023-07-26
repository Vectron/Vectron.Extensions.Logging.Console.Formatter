using ConsoleDemo;
using ConsoleDemo.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vectron.Extensions.Logging.Console.Formatter;

var builder = Host.CreateApplicationBuilder(args);

var loggingConfig = new LoggingConfiguration("Logging");
builder.Configuration.AddLoggingConfiguration(loggingConfig);

builder.Services
    .Configure<SingleLineConsoleFormatterOptions>(options =>
    {
        options.UseUtcTimestamp = true;
        options.IncludeScopes = true;
        options.TimestampFormat = "HH:mm:ss";
        options.ColorWholeLine = false;
        options.ColorMode = ColorMode.MEL;
    });

builder.Logging
    .AddSingleLineConsole();

using var host = builder.Build();

loggingConfig.SetLogLevel(LogLevel.Trace, "Console", "Default");
var logger = host.Services.GetRequiredService<ILogger<Program>>();

loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorMode), ColorMode.MEL);
Console.WriteLine("Microsoft.Extensions.Logging.Console Colors:");
LogTest.WriteLogs(logger);
Console.WriteLine();
Console.ReadLine();
Console.Clear();
Console.Clear();

loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorMode), ColorMode.NLog);
Console.WriteLine("NLog Colors:");
LogTest.WriteLogs(logger);
Console.WriteLine();
Console.ReadLine();
Console.Clear();
Console.Clear();

loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorMode), ColorMode.Serilog);
Console.WriteLine("Serilog Colors:");
LogTest.WriteLogs(logger);
Console.WriteLine();
Console.ReadLine();
Console.Clear();
Console.Clear();

loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorWholeLine), value: true);
loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorMode), ColorMode.MEL);
Console.WriteLine("Microsoft.Extensions.Logging.Console Colors (whole line):");
LogTest.WriteLogs(logger);
Console.WriteLine();
Console.ReadLine();
Console.Clear();
Console.Clear();

loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorMode), ColorMode.NLog);
Console.WriteLine("NLog Colors (whole line):");
LogTest.WriteLogs(logger);
Console.WriteLine();
Console.ReadLine();
Console.Clear();
Console.Clear();

loggingConfig.SetConsoleFormatterOption(nameof(SingleLineConsoleFormatterOptions.ColorMode), ColorMode.Serilog);
Console.WriteLine("Serilog Colors (whole line):");
LogTest.WriteLogs(logger);
Console.WriteLine();
Console.ReadLine();
Console.Clear();
Console.Clear();

Console.ReadLine();
