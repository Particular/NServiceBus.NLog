using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

class Program
{
    static async Task Main()
    {
        LoggingConfig.ConfigureNLog();
        LogManager.Use<NLogFactory>();

        var configuration = new EndpointConfiguration("NLogSample");
        configuration.EnableInstallers();
        configuration.UseTransport<LearningTransport>();
        var endpoint = await Endpoint.Start(configuration)
            .ConfigureAwait(false);
        await endpoint.SendLocal(new MyMessage());
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpoint.Stop()
            .ConfigureAwait(false);
    }
}