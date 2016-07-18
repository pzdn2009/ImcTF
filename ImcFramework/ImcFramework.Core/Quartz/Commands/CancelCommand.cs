using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.Core.IsolatedAd;

namespace ImcFramework.Core.Quartz.Commands
{
    public class CancelCommand : AbstractSchedulerCommand
    {
        public CancelCommand(IScheduler schedule) : base(schedule)
        {
        }

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
