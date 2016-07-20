using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImcFramework.Winform.Common
{
    /// <summary>
    /// ServiceType & WcfClient Mapping
    /// </summary>
    public class ServiceTypeWcfClient : Dictionary<EServiceType, WsDualClient>
    {
        public void CloseWcfConnections()
        {
            var connections = this.ToList();
            for (int i = connections.Count - 1; i >= 0; i--)
            {
                CloseWcfConnection(connections[i].Key);
            }
        }

        public bool CloseWcfConnection(EServiceType serviceType)
        {
            try
            {
                if (this.ContainsKey(serviceType))
                {
                    if (this[serviceType].Factory.State != System.ServiceModel.CommunicationState.Faulted)
                    {
                        this[serviceType].ClientConnector.UnRegister(serviceType);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.ContainsKey(serviceType))
                {
                    this[serviceType].Factory.Abort();
                    this.Remove(serviceType);
                }
            }
            return false;
        }
    }
}
