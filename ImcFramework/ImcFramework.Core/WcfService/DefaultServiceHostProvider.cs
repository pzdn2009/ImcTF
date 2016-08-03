using System.ServiceModel;

namespace ImcFramework.Core.WcfService
{
    public class DefaultServiceHostProvider : IServiceHostProvider
    {
        public DefaultServiceHostProvider(ServiceHost serviceHost)
        {
            ServiceHost = serviceHost;
        }

        public ServiceHost ServiceHost { get; private set; }
    }
}
