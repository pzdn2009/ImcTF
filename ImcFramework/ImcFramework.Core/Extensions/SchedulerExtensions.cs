using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.Extensions
{
    public static class SchedulerExtensions
    {
        public static void Cancel(this IScheduler scheduler, string serviceType)
        {

        }

        public static void Stop(this IScheduler scheduler, string serviceType)
        {

        }

        public static void Pause(this IScheduler scheduler, string serviceType)
        {

        }

        public static void RunRightNow(this IScheduler scheduler,string serviceType)
        {

        }

        public static void Continue(this IScheduler scheduler, string serviceName)
        {
            if (scheduler != null && scheduler.IsStarted)
            {
                scheduler.ResumeTrigger(serviceName.GetTriggerKey());
            }
        }
    }
}
