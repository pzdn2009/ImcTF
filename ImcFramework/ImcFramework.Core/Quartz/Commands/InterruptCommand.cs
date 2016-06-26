using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.Core.IsolatedAd;
using Quartz;

namespace ImcFramework.Core.Quartz.Commands
{
    public class InterruptCommand : AbstractSchedulerCommand
    {
        public InterruptCommand(IScheduler schedule) : base(schedule)
        {

        }

        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.Interrupt)
            {
                var serviceName = input.ServiceType.ServiceType;

                if (GetStatus(serviceName) != EServiceStatus.Running)
                    return;

                var job = Scheduler.GetCurrentlyExecutingJobs().FirstOrDefault(zw => zw.JobDetail.Key.Name == serviceName);
                if (job == null)
                {
                    return;
                }

                var interrupt = job.JobInstance as IsolatedJob;
                interrupt.Interrupt();
            }
        }
    }
}
