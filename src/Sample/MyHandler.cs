using System;
using NServiceBus;
using NServiceBus.Logging;

public class MyHandler : IHandleMessages<MyMessage>
{
    static ILog logger = LogManager.GetLogger(typeof(MyHandler));

    public void Handle(MyMessage message)
    {
        logger.Info("Hello from MyHandler");
        try
        {
            throw new Exception("The message");
        }
        catch (Exception exception)
        {
            logger.Error("Hello from MyHandler", exception);
        }
    }

}