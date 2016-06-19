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
        public WsDualClient(string endpointName)
        {
            this.m_EndpointName = endpointName;

            InitChannel();
        }

        private static DuplexChannelFactory<IClientConnector> m_ChannelFactory;
        public DuplexChannelFactory<IClientConnector> Factory
        {
            get
            {
                if (m_ChannelFactory == null)
                {
                    var instanceContext = new InstanceContext(new MainConnectorCallback());
                    m_ChannelFactory = new DuplexChannelFactory<IClientConnector>(instanceContext, m_EndpointName);
                }
                return m_ChannelFactory;
            }
        }

        private void InitChannel()
        {
            this.ClientConnector = Factory.CreateChannel();
        }

        public IClientConnector ClientConnector { get; set; }

    }
}
