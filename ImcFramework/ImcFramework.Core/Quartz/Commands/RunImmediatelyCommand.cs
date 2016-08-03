using Quartz;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// Run immediately command.
    /// </summary>
    public class RunImmediatelyCommand : AbstractSchedulerCommand
    {
        public RunImmediatelyCommand(IScheduler scheduler) : base(scheduler)
        {

        }

        /// <summary>
        /// Execute the <see cref="ECommand.RunImmediately"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
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
