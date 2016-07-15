using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.WcfService
{
    public interface IServiceTypeFilter
    {
        bool Filter(EServiceType serviceType);
    }

    public class DefaultServiceTypeFilter : IServiceTypeFilter
    {
        public bool Filter(EServiceType serviceType)
        {
            return true;
        }
    }
}
