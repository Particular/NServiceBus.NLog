namespace NServiceBus
{
    using Logging;
    using NServiceBusNLog;

    /// <summary>
    /// Configure NServiceBus logging messages to use NLog. User by calling LogManager.UseLogging&lt;NLog&gt;.
    /// </summary>
    public class NLogFactory : LoggingFactoryDefinition
    {

        /// <summary>
        /// <see cref="LoggingFactoryDefinition.GetLoggingFactory"/>.
        /// </summary>
        public override ILoggerFactory GetLoggingFactory()
        {
            return new LoggerFactory();
        }
    }
}