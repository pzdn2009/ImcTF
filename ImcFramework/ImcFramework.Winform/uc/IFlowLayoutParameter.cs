using System.Windows.Forms;
using ImcFramework.WcfInterface;
using System.Collections.Generic;

namespace ImcFramework.Winform.uc
{
    public interface IFlowLayoutParameter
    {
        FlowLayoutPanel GetFlowLayoutPanel(RequestParameter requestParameter);

        RequestParameter GetRequestParameter(FlowLayoutPanel flp);

        RequestParameterList GetRequestParameters(IEnumerable<FlowLayoutPanel> flps);
    }
}
