using ImcFramework.Core.MutilUserProgress;
using Quartz;
using System.ServiceModel;

namespace ImcFramework.Core
{
    /// <summary>
    /// Service context for the extension modules
    /// </summary>
    public class ServiceContext
    {
        /// <summary>
        /// Service host for the framework ,which providers communication with the wcf clients.
        /// </summary>
        public ServiceHost WcfHost { get; set; }

        /// <summary>
        /// Scheduler for the framework,whick schedules the jobs.
        /// </summary>
        public IScheduler Scheduler { get; set; }

        /// <summary>
        /// Progress manager for the jobs.
        /// </summary>
        public IProgressInfoManager ProgressInfoManager { get; set; }
    }
}
