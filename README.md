# Vectron.Extensions.Logging.Console.Formatter
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE.txt)
[![Build status](https://github.com/Vectron/Vectron.Extensions.Logging.Console.Formatter/actions/workflows/BuildTestDeploy.yml/badge.svg)](https://github.com/Vectron/Vectron.Extensions.Logging.Console.Formatter/actions)
[![NuGet](https://img.shields.io/nuget/v/Vectron.Extensions.Logging.Console.Formatter.svg)](https://www.nuget.org/packages/Vectron.Extensions.Logging.Console.Formatter)

Vectron.Extensions.Logging.Console.Formatter provides a custom formatter for [Microsoft.Extensions.Logging.Console](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging.Console/src)
it is based on the SimpleConsoleFormatter.

## Changes with default simple formatter
1. The message will be single line, but preserves new lines in the message.
2. The Level text is changed to capitals and full word  
    trce -> TRACE  
    dbug -> DEBUG  
    info -> INFO  
    warn -> WARN  
    fail -> FAIL  
    crit -> CRIT  
3. Added a '-' between scope and message

output examples:  
[Microsoft.Extensions.Logging level only](assets/MelLevelOnly.png)  
[Microsoft.Extensions.Logging Full line](assets/MelFullLine.png)  

[NLog level only](assets/NLogLevelOnly.png)  
[NLog Full line](assets/NLogFullLine.png)  

[Serilog level only](assets/SerilogLevelOnly.png)  
[Serilog Full line](assets/SerilogFullLine.png)  

## Setup
### From code

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

### With settings file
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
