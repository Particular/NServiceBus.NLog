namespace NServiceBus.NLog
{
    using Logging;

    /// <summary>
    /// Configure NServiceBus logging messages to use NLog.
    /// </summary>
    public static class NLogConfigurator
    {

        /// <summary>
        /// Configure NServiceBus logging messages to use NLog. This method should be called before <see cref="NServiceBus.Configure.With()"/>.
        /// </summary>
        public static void Configure()
        {
            var loggerFactory = new LoggerFactory();
            LogManager.LoggerFactory = loggerFactory;
        }
    }
}