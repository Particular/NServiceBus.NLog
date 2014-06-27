using System.Collections.Generic;
using NLog;
using NLog.Config;
using NServiceBus;
using NServiceBus.Persistence;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void Ensure_log_messages_are_redirected()
    {
        ConfigLogging();

        var configure = Configure.With(builder => builder.EndpointName(() => "NLogTests"));
        configure.UseSerialization<Json>();
        configure.UsePersistence<InMemory>();
        configure.EnableInstallers();

        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Assert.IsNotEmpty(messages);
        }
    }

    void ConfigLogging()
    {
        var config = new LoggingConfiguration();
        var target = new ActionTarget
        {
            Action = LogEvent
        };

        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, target));
        config.AddTarget("debugger", target);
        LogManager.Configuration = config;


        NServiceBus.NLog.NLogConfigurator.Configure();
    }

    void LogEvent(LogEventInfo obj)
    {
        messages.Add(obj);
    }

    List<LogEventInfo> messages = new List<LogEventInfo>();
}