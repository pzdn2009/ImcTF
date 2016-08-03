using System.ServiceModel;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// Service host provider.
    /// </summary>
    public interface IServiceHostProvider
    {
        ServiceHost ServiceHost { get; }
    }
}
