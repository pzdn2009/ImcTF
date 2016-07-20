using Common.Logging;
using ImcFramework.Core;
using ImcFramework.Core.Quartz;
using ImcFramework.WcfInterface;
using Quartz;
using System.Threading;

namespace MyProjectCore
{
    public class ImcTFSampleService : MainBusinessBase
    {
        public override EServiceType ServiceType
        {
            get
            {
                return new EServiceType("ImcTFSample", "框架示例服务");
            }
        }

        public override void ExecuteCore(IJobExecutionContext context)
        {
            NotifyAndLog("开始！", LogLevel.Info);

            var p = context.GetParameter<string>("Site");
            NotifyAndLog("Site：" + p, LogLevel.Info);

            var p2 = context.GetParameters<string>("SellerAccount");
            NotifyAndLog("SellerAccount：" + p, LogLevel.Info);

            NotifyAndLog("结束！", LogLevel.Info);

            MutilUserProgress.SendTaskProgressTotal(2, TotalType.User);
            MutilUserProgress.SendTaskProgressItemTotal("PZ", 10);
            MutilUserProgress.SendTaskProgressItemTotal("DN", 15);

            for (int i = 0; i < 10; i++)
            {
                MutilUserProgress.SendTaskProgressIncrease("PZ");
                Thread.Sleep(300);
                NotifyAndLog("A:" + i, LogLevel.Info, "PZ");
            }

            for (int i = 0; i < 15; i++)
            {
                MutilUserProgress.SendTaskProgressIncrease("DN");
                Thread.Sleep(200);
                NotifyAndLog("B:" + i, LogLevel.Info, "DN");
            }
        }
    }
}
