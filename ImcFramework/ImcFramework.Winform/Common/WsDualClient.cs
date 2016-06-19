using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Winform.Common
{
    public class WsDualClient
    {
        private string m_EndpointName = null;
        private IMessageCallback m_MessageCallback = null;

        public WsDualClient(string endpointName)
            : this(endpointName, new MainConnectorCallback())
        {

        }

        public WsDualClient(string endpointName, IMessageCallback messageCallback)
        {
            Guard.IsNull(endpointName);
            Guard.IsNull(messageCallback);

            this.m_EndpointName = endpointName;
            this.m_MessageCallback = messageCallback;

            InitChannel();
        }

        private void InitChannel()
        {
            Factory = new DuplexChannelFactory<IClientConnector>(m_MessageCallback, m_EndpointName);
            this.ClientConnector = Factory.CreateChannel();
        }

        public DuplexChannelFactory<IClientConnector> Factory { get; set; }

        public IClientConnector ClientConnector { get; set; }

    }
}
