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
                if (GetStatus(input.ServiceType) == EServiceStatus.Running)
                    return;

                var serviceTypeKey = input.ServiceType.GetFullString();
                if (RunOnce.Exist(serviceTypeKey))
                    return;

                RunOnce.Add(serviceTypeKey);

                var job = Scheduler.GetJobDetail(input.ServiceType.ToJobKey());
                if (job != null)
                {
                    Scheduler.TriggerJob(job.Key, ConvertToJobDataMap(input.RequestParameterList));
                }

                RunOnce.Remove(serviceTypeKey);
            }
        }
    }
}
