using ImcFramework.WcfInterface;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImcFramework.Winform.Common
{
    public class ServiceTypeTabPage : Dictionary<EServiceType, TabPage>
    {
        public void CloseTabPage(TabPage tabPage)
        {
            bool exist = this.ContainsValue(tabPage);
            if (exist)
            {
                var serviceType = this.First(zw => zw.Value == tabPage).Key;
                this.Remove(serviceType);
            }
        }

        public void CloseTabPage(string serviceType)
        {
            var key = Keys.FirstOrDefault(zw => zw.ServiceType == serviceType);
            if (key != null)
            {
                Remove(key);
            }
        }

        public void CloseTabPage(EServiceType serviceType)
        {
            if (ContainsKey(serviceType))
            {
                Remove(serviceType);
            }
        }
    }

}
