using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

class Program
{
    static async Task Main()
    {
        LoggingConfig.ConfigureNLog();
#pragma warning disable 0618
        LogManager.Use<NLogFactory>();
#pragma warning restore 0618

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