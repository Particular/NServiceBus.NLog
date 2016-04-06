using System.Collections.Generic;
using NLog;
using NLog.Config;

class LogMessageCapture
{
   public static List<LogEventInfo> LoggingEvents = new List<LogEventInfo>();
    public static void CaptureLogMessages()
    {
        var config = new LoggingConfiguration();
        var target = new ActionTarget
        {
            Action = info => LoggingEvents.Add(info)
        };

        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, target));
        config.AddTarget("debugger", target);
        LogManager.Configuration = config;

    }
}