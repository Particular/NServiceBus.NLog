using System;
using System.ServiceProcess;
using NServiceBus;
using NServiceBus.Persistence;

class ProgramService : ServiceBase
{
    static void Main()
    {
        LoggingConfig.ConfigureNLog();

        var configure = Configure.With(builder => builder.EndpointName(() => "SelfHost"));
        configure.DefaultBuilder();
        configure.Serialization.Json();
        configure.UsePersistence<InMemory>();
        configure.ForInstallationOn();

        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
            bus.Shutdown();
        }
    }

}