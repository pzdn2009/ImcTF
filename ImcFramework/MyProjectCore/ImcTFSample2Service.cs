using Common.Logging;
using ImcFramework.Core;
using ImcFramework.Core.Quartz;
using ImcFramework.WcfInterface;
using Quartz;

namespace MyProjectCore
{
    public class ImcTFSample2Service : MainBusinessBase
    {
        public override EServiceType ServiceType
        {
            get
            {
                return new EServiceType("ImcTFSample2", "框架示例服务2", "MyGroup");
            }
        }

        public override void ExecuteCore(IJobExecutionContext context)
        {
            NotifyAndLog("开始！", LogLevel.Info);

            var p = context.GetParameters<string>("SellerAccount");
            NotifyAndLog("SellerAccount：" + p, LogLevel.Info);

            NotifyAndLog("结束！", LogLevel.Info);
        }
    }
}
