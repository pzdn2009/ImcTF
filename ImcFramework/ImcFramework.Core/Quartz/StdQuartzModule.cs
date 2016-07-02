using ImcFramework.Core.IsolatedAd;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using Quartz;
using Quartz.Impl;

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

            IocManager.Register<ISchedulerFactory, StdSchedulerFactory>(DependencyLifeStyle.Singleton);
        }

        public override void Start()
        {
            base.Start();

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

            IocManager.Register<IScheduler>(scheduler);
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
