using NServiceBus;
using NServiceBus.Logging;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void Ensure_log_messages_are_redirected()
    {
        LogMessageCapture.CaptureLogMessages();
        LogManager.Use<NLogFactory>();

        var busConfig = new BusConfiguration();
        busConfig.EndpointName("NLogTests");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            Assert.IsNotEmpty(LogMessageCapture.Messages);
        }
    }
}