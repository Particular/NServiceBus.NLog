namespace NServiceBus
{
    using Logging;
    using Logging.NLog;

    /// <summary>
    /// Configure NServiceBus logging messages to use NLog.  Use by calling <see cref="LogManager.Use{T}"/> the T is <see cref="NLogFactory"/>.
    /// </summary>
    [ObsoleteEx(
        Message = "Support for external logging providers is no longer provided by NServiceBus providers for each logging framework. Instead, the NServiceBus.Extensions.Logging library provides the ability to use any logging provider that conforms to the Microsoft.Extensions.Logging abstraction.",
        RemoveInVersion = "5.0.0",
        TreatAsErrorFromVersion = "4.0.0")]
    public class NLogFactory : LoggingFactoryDefinition
    {
        /// <summary>
        /// <see cref="LoggingFactoryDefinition.GetLoggingFactory"/>.
        /// </summary>
        protected override ILoggerFactory GetLoggingFactory()
        {
            return new LoggerFactory();
        }
    }
}