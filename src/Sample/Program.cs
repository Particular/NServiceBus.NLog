using System;
using System.ServiceProcess;
using NServiceBus;
using NServiceBus.Logging;

class ProgramService : ServiceBase
{
    static void Main()
    {
        LoggingConfig.ConfigureNLog();
        LogManager.Use<NLogFactory>();

        var busConfig = new BusConfiguration();
        busConfig.EndpointName("NLogSample");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();
        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
        }

    }

}