using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImcFramework.WcfInterface;
using Quartz;
using System.Threading;
using Common.Logging;

namespace ImcFramework.Core.BuildInBusinessService
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

        //public override void Execute(IJobExecutionContext context)
        //{
        //    NotifyAndLog("开始！", LogLevel.Info);

        //    Thread.Sleep(2000);

        //    NotifyAndLog("结束！", LogLevel.Info);
        //}

        public override void ExecuteCore(IJobExecutionContext context)
        {
            NotifyAndLog("开始！", LogLevel.Info);

            Thread.Sleep(2000);

            NotifyAndLog("结束！", LogLevel.Info);

            SellerAccountProgress.SendTaskProgressTotal(2, TotalType.SellerAccountCount);
            SellerAccountProgress.SendTaskProgressItemTotal("PZ", 10);
            SellerAccountProgress.SendTaskProgressItemTotal("DN", 15);

            for (int i = 0; i < 10; i++)
            {
                SellerAccountProgress.SendTaskProgressIncrease("PZ");
                Thread.Sleep(300);
                NotifyAndLog("A:" + i, LogLevel.Info, "PZ");
            }

            for (int i = 0; i < 15; i++)
            {
                SellerAccountProgress.SendTaskProgressIncrease("DN");
                Thread.Sleep(200);
                NotifyAndLog("B:" + i, LogLevel.Info, "DN");
            }
        }
    }
}
