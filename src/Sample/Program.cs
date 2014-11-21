using System;
using NServiceBus;
using NServiceBus.Logging;

class Program 
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
            bus.SendLocal(new MyMessage());
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
        }

    }

}