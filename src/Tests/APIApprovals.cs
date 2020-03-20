using NServiceBus;
using NUnit.Framework;
using Particular.Approvals;
using PublicApiGenerator;

[TestFixture]
public class APIApprovals
{
    [Test]
    public void Approve()
    {
#pragma warning disable 0618
        var publicApi = ApiGenerator.GeneratePublicApi(typeof(NLogFactory).Assembly, excludeAttributes: new[] { "System.Runtime.Versioning.TargetFrameworkAttribute" });
#pragma warning restore 0618
        Approver.Verify(publicApi);
    }
}