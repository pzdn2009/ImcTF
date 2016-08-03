using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;
using Quartz;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// GetServiceInfo command.
    /// </summary>
    public class GetServiceInfoCommand : AbstractSchedulerCommand<GetServiceInfoOutput>
    {
        public GetServiceInfoCommand(IScheduler schedule) : base(schedule)
        {

        }

        /// <summary>
        /// Execute the <see cref="ECommand.GetServiceInfo"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
        protected override void ExecuteCore(FunctionSwitch input, GetServiceInfoOutput output)
        {
            if (input.Command == ECommand.GetServiceInfo)
            {
                var serviceInfo = new ServiceInfo();

                serviceInfo.EServiceStatus = GetStatus(input.ServiceType);
                serviceInfo.Enable = serviceInfo.EServiceStatus != EServiceStatus.Pause;

                var trigger = Scheduler.GetTrigger(input.ServiceType);
                if (trigger != null)
                {
                    var cronBuilder = trigger as ICronTrigger;
                    serviceInfo.ScheduleInfo = JobCronExpressionConfig.GetCronExpression(trigger);
                    var prev = trigger.GetPreviousFireTimeUtc();
                    if (prev.HasValue)
                    {
                        serviceInfo.PrevFiredTime = prev.Value.LocalDateTime;
                    }

                    var next = trigger.GetNextFireTimeUtc();
                    if (next.HasValue)
                    {
                        serviceInfo.NextFiredTime = next.Value.LocalDateTime;
                    }
                }
                else
                {
                    serviceInfo.ScheduleInfo = string.Empty;
                }

                output.ServiceInfo = serviceInfo;
            }
        }
    }
}
