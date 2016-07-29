using System.ServiceModel;

namespace ImcFramework.Core.WcfService
{
    public interface IServiceHostProvider
    {
        ServiceHost ServiceHost { get; }
    }
}
