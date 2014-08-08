using System;
using System.ServiceProcess;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Persistence;

class ProgramService : ServiceBase
{
    static void Main()
    {
        LoggingConfig.ConfigureNLog();
        LogManager.Use<NLogFactory>();

        var configure = Configure.With(b => {
            {
                b.EndpointName("SelfHost");
                b.UseSerialization<Json>();
                b.EnableInstallers();
            } });
        configure.UsePersistence<InMemory>();

        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
            bus.Shutdown();
        }
    }

}