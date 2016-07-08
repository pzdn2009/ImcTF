using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImcFramework.WcfInterface;

namespace ImcFramework.Core.WcfService
{
    public class DefaultRequestParameterProvider : IRequestParameterProvider
    {
        public RequestParameterList GetRequestParameter(EServiceType serviceType)
        {
            return new RequestParameterList();
        }
    }
}
