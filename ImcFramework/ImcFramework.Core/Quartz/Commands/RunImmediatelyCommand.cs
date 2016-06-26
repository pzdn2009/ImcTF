using Quartz;
using System;
using ImcFramework.Data;
using ImcFramework.WcfInterface;

namespace ImcFramework.Core.Quartz.Commands
{
    public class RunImmediatelyCommand : AbstractSchedulerCommand
    {
        public RunImmediatelyCommand(IScheduler scheduler) : base(scheduler)
        {

        }

        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.RunImmediately)
            {
                var serviceName = input.ServiceType.ServiceType;
                if (GetStatus(serviceName) == EServiceStatus.Running)
                    return;

                if (RunOnce.Exist(serviceName))
                    return;

                RunOnce.Add(serviceName);

                var job = Scheduler.GetJobDetail(serviceName.GetJobKey());
                if (job != null)
                {
                    Scheduler.TriggerJob(job.Key);
                }

                RunOnce.Remove(serviceName);
            }
        }
    }
}
