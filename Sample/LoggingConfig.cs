using NLog;
using NLog.Config;
using NLog.Targets;

public class LoggingConfig
{
    public static void ConfigureNLog()
    {
        var config = new LoggingConfiguration();

        var consoleTarget = new ColoredConsoleTarget
        {
            Layout = "${level:uppercase=true}|${logger}|${message}${onexception:${newline}${exception:format=tostring}}"
        };
        config.AddTarget("console", consoleTarget);
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));

        var fileTarget = new FileTarget
        {
            FileName = "${basedir}/nsb_log_${date:format=yyyy-MM-dd}.txt",
            ArchiveDateFormat = "yyyy-MM-dd",
            Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}${onexception:${newline}${exception:format=tostring}}",
            ArchiveAboveSize = 10 * 1024 *1024,
            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveNumbering = ArchiveNumberingMode.Rolling,
            MaxArchiveFiles = 10,
            KeepFileOpen = false
        };
        config.AddTarget("file", fileTarget);
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));

        LogManager.Configuration = config;

    }
}