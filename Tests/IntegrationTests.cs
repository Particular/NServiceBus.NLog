using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Persistence;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void Ensure_log_messages_are_redirected()
    {
        LogMessageCapture.CaptureLogMessages();
        LogManager.Use<NLogFactory>();

        var configure = Configure.With(b =>
        {
            b.EndpointName("NLogTests");
            b.UseSerialization<Json>();
            b.EnableInstallers();
        });
        configure.UsePersistence<InMemory>();

        using (var bus = configure.CreateBus())
        {
            bus.Start();
            Assert.IsNotEmpty(LogMessageCapture.Messages);
        }
    }
}