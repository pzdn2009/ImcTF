using ImcFramework.Core.IsolatedAd;
using ImcFramework.Ioc;
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
        private IScheduler scheduler;

        public override string Name
        {
            get
            {
                return "Quartz";
            }
        }

        public override void Initialize()
        {
            IocManager.Register<ISchedulerFactory, StdSchedulerFactory>(DependencyLifeStyle.Singleton);
        }

        public override void Start()
        {
            var isolatedJob = Defaults.IsIsolatedJob;

            var schedulerFactory = IocManager.Resolve<ISchedulerFactory>();

            scheduler = schedulerFactory.GetScheduler();
            scheduler.ListenerManager.AddJobListener(new GlobalJobListener());
            scheduler.ListenerManager.AddTriggerListener(new GlobalTriggerListener());

            if (isolatedJob)
            {
                scheduler.JobFactory = new IsolatedJobFactory();
            }

            scheduler.Start();

            IocManager.Register(scheduler);
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
