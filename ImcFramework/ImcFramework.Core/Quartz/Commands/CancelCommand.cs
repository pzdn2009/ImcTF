using Quartz;
using System.Linq;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.Core.IsolatedAd;
using ImcFramework.WcfInterface.Enums;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// Cancel command.
    /// </summary>
    public class CancelCommand : AbstractSchedulerCommand
    {
        public CancelCommand(IScheduler schedule) : base(schedule)
        {
        }

        /// <summary>
        /// Execute the <see cref="ECommand.Cancel"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.Cancel)
            {
                if (GetStatus(input.ServiceType) != EServiceStatus.Running)
                    return;

                var job = Scheduler.GetCurrentlyExecutingJobs().FirstOrDefault(zw => zw.JobDetail.Key.Equals(input.ServiceType.ToJobKey()));
                if (job == null)
                {
                    return;
                }

                if (!Defaults.IsIsolatedJob)
                {
                    var cancel = job.JobInstance as ICancel;
                    cancel.Cancel();
                }
                else
                {
                    var cancel = job.JobInstance as IsolatedJob;
                    cancel.Cancel();
                }
            }
        }
    }
}
