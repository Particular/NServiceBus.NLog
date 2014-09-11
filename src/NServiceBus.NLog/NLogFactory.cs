namespace NServiceBus
{
    using Logging;
    using NServiceBusNLog;

    /// <summary>
    /// Configure NServiceBus logging messages to use NLog.  Use by calling <see cref="LogManager.Use{T}"/> the T is <see cref="NLogFactory"/>.
    /// </summary>
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