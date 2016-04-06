using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public async Task Ensure_log_messages_are_redirected()
    {
        LogMessageCapture.CaptureLogMessages();
        LogManager.Use<NLogFactory>();

        var endpointConfiguration = new EndpointConfiguration("NLogTests");
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.UsePersistence<InMemoryPersistence>();

        var endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            Assert.IsNotEmpty(LogMessageCapture.LoggingEvents);
        }
        finally
        {
            await endpoint.Stop();
        }
    }
}