using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
