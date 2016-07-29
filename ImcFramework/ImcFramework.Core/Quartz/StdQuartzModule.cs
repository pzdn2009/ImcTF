using ImcFramework.Core.IsolatedAd;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using Quartz;
using Quartz.Impl;
using System.Collections.Generic;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Quartz.net Module
    /// </summary>
    public class StdQuartzModule : ServiceModuleBase
    {
        public const string MODUEL_NAME = "Quartz_Module";

        private IScheduler scheduler;
        public StdQuartzModule()
        {
        }

        public override string Name
        {
            get
            {
                return MODUEL_NAME;
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            IocManager.Register<IScheduler>(new StdSchedulerFactory().GetScheduler());
        }

        public override void Start()
        {
            base.Start();

            var isolatedJob = Defaults.IsIsolatedJob;

            scheduler = IocManager.Resolve<IScheduler>();
            if (isolatedJob)
            {
                scheduler.JobFactory = new IsolatedJobFactory();
            }

            scheduler.Start();

            var jobListeners = IocManager.Resolve<IEnumerable<IJobListener>>();
            foreach (var jobListener in jobListeners)
            {
                scheduler.ListenerManager.AddJobListener(jobListener);
            }

            var triggerListeners = IocManager.Resolve<IEnumerable<ITriggerListener>>();
            foreach (var triggerListener in triggerListeners)
            {
                scheduler.ListenerManager.AddTriggerListener(triggerListener);
            }
        }

        public override void Stop()
        {
            if (scheduler != null)
            {
                scheduler.Shutdown(true);
            }

            base.Stop();
        }
    }
}
