namespace NServiceBus.Logging.NLog
{
    using System;
    using Logging;
    using NLogLogManager = global::NLog.LogManager;

    class LoggerFactory : ILoggerFactory
    {

        public ILog GetLogger(Type type)
        {
            var logger = NLogLogManager.GetLogger(type.FullName);
            return new Logger(logger);
        }

        public ILog GetLogger(string name)
        {
            var logger = NLogLogManager.GetLogger(name);
            return new Logger(logger);
        }
    }
}