using ImcFramework.Core.IsolatedAd;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Quartz.net Module
    /// </summary>
    public class StdQuartzModule : ServiceModuleBase
    {
        private static ISchedulerFactory schedulerFactory;
        private static IScheduler scheduler;

        public override string Name
        {
            get
            {
                return "Quartz";
            }
        }

        public IScheduler Scheduler { get { return scheduler; } }

        public override void Start()
        {
            var isolatedJob = Defaults.IsIsolatedJob;

            if (schedulerFactory == null)
            {
                schedulerFactory = new StdSchedulerFactory();
                if (scheduler == null || !scheduler.IsStarted)
                {
                    scheduler = schedulerFactory.GetScheduler();
                    scheduler.ListenerManager.AddJobListener(new GlobalJobListener());
                    scheduler.ListenerManager.AddTriggerListener(new GlobalTriggerListener());

                    if (isolatedJob)
                    {
                        scheduler.JobFactory = new IsolatedJobFactory();
                    }

                    scheduler.Start();
                }
            }
        }

        public override void Stop()
        {
            if (scheduler != null)
            {
                scheduler.Shutdown(true);
            }
        }
    }
}
