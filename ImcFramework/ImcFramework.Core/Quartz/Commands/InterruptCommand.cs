using System.Linq;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.Core.IsolatedAd;
using Quartz;
using ImcFramework.WcfInterface.Enums;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// Interrupt command.
    /// </summary>
    public class InterruptCommand : AbstractSchedulerCommand
    {
        public InterruptCommand(IScheduler schedule) : base(schedule)
        {

        }

        /// <summary>
        /// Execute the <see cref="ECommand.Interrupt"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.Interrupt)
            {
                if (GetStatus(input.ServiceType) != EServiceStatus.Running)
                    return;

                var job = Scheduler.GetCurrentlyExecutingJobs().FirstOrDefault(zw => zw.JobDetail.Key.Equals(input.ServiceType.ToJobKey()));
                if (job == null)
                {
                    return;
                }

                if (Defaults.IsIsolatedJob)
                {
                    var interrupt = job.JobInstance as IsolatedJob;
                    interrupt?.Interrupt();
                }
                else
                {
                    var interrupt = job.JobInstance as IInterruptableJob;
                    interrupt?.Interrupt();
                }
            }
        }
    }
}
