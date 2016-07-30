using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ImcFramework.Winform.Common
{
    public class WsDualClient : IClientConnector
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

        public void Register(EServiceType serviceType)
        {
            ClientConnector.Register(serviceType);
        }

        public void UnRegister(EServiceType serviceType)
        {
            ClientConnector.UnRegister(serviceType);
        }

        public List<EServiceType> GetServiceList()
        {
            return Factory.CreateChannel().GetServiceList();
        }

        public async Task<List<EServiceType>> GetServiceListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return GetServiceList();
            });
        }

        public void RequestSwitch(FunctionSwitch singleSwitch)
        {
            ClientConnector.RequestSwitch(singleSwitch);
        }

        public void RequestSwitchs(IEnumerable<FunctionSwitch> switchs)
        {
            ClientConnector.RequestSwitchs(switchs);
        }

        public ServiceInfo GetServiceInfo(EServiceType serviceType)
        {
            return ClientConnector.GetServiceInfo(serviceType);
        }

        public IEnumerable<LogInfo> GetLogInfoDates(EServiceType serviceType)
        {
            return ClientConnector.GetLogInfoDates(serviceType);
        }

        public void GetLogInfos(EServiceType serviceType, string date, string sellerAccount, string logLevel)
        {
            ClientConnector.GetLogInfos(serviceType, date, sellerAccount, logLevel);
        }

        public ProgressSummary GetProgressTotal(EServiceType serviceType)
        {
            return ClientConnector.GetProgressTotal(serviceType);
        }

        public ProgressItem GetProgressSellerAccountTotal(EServiceType serviceType, string sellerAccount)
        {
            return ClientConnector.GetProgressSellerAccountTotal(serviceType, sellerAccount);
        }

        public bool Login(string userName, string password)
        {
            return ClientConnector.Login(userName, password);
        }

        public RequestParameterList GetRequestParameter(EServiceType serviceType)
        {
            return ClientConnector.GetRequestParameter(serviceType);
        }

        public DuplexChannelFactory<IClientConnector> Factory { get; set; }

        public IClientConnector ClientConnector { get; set; }

    }
}
