using System.Windows.Forms;
using ImcFramework.WcfInterface;

namespace ImcFramework.Winform.uc
{
    public interface IFlowLayoutParameter
    {
        FlowLayoutPanel GetFlowLayoutPanel(RequestParameter requestParameter);
    }
}
