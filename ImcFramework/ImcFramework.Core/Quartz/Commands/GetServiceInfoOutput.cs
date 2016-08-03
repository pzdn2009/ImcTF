using ImcFramework.Data;
using ImcFramework.WcfInterface;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// The GetServiceInfo output
    /// </summary>
    public class GetServiceInfoOutput : ExecuteResult
    {
        public ServiceInfo ServiceInfo { get; set; }
    }
}
