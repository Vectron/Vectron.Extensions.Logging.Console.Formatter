# Vectron.Extensions.Logging.Console.Formatter
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/Vectron/Vectron.Extensions.Logging.Console.Formatter/blob/main/LICENSE.txt)
[![Build status](https://github.com/Vectron/Vectron.Extensions.Logging.Console.Formatter/actions/workflows/BuildTestDeploy.yml/badge.svg)](https://github.com/Vectron/Vectron.Extensions.Logging.Console.Formatter/actions)
[![NuGet](https://img.shields.io/nuget/v/Vectron.Extensions.Logging.Console.Formatter.svg)](https://www.nuget.org/packages/Vectron.Extensions.Logging.Console.Formatter)

Vectron.Extensions.Logging.Console.Formatter provides a custom formatter for [Microsoft.Extensions.Logging.Console](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging.Console/src)
it is based on the SimpleConsoleFormatter.

differences are:
1. The message will be single line, but preserves new lines in the message.
2. The Level text is changed to captials and full word  
    trce -> TRACE  
    dbug -> DEBUG  
    info -> INFO  
    warn -> WARN  
    fail -> FAIL  
    crit -> CRIT  

example output:  
08:30:13 INFO Microsoft.Hosting.Lifetime[0] Hosting environment: Production

To use the SingleLine formatter register it with the ILoggingBuilder:
```C#
using ILoggerFactory loggerFactory =
    LoggerFactory.Create(builder =>
        builder.AddSingleLineConsole(options =>
        {
            options.IncludeScopes = true;
            options.TimestampFormat = "HH:mm:ss ";
            options.UseUtcTimestamp = true;
        }));
```

or when using configuration files:
```C#
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Logging
    .AddConsole()
    .AddSingleLineConsoleFormatter();
using IHost host = builder.Build();
```

```json
{
    "Logging": {
        "Console": {
            "FormatterName": "SingleLineFormatter",
            "FormatterOptions": {
                "IncludeScopes": true,
                "TimestampFormat": "HH:mm:ss.ffff ",
                "UseUtcTimestamp": true,
            }
        }
    }
}
```

## Authors
- [@Vectron](https://www.github.com/Vectron)
