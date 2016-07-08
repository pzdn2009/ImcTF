using ImcFramework.WcfInterface;
using System.Collections.Generic;

namespace ImcFramework.Core.WcfService
{
    public interface IRequestParameterProvider
    {
        RequestParameterList GetRequestParameter(EServiceType serviceType);
    }
}
