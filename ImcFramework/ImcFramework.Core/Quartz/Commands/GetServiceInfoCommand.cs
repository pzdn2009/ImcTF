using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using Quartz;
using ImcFramework.Commands;

namespace ImcFramework.Core.Quartz.Commands
{
    public class GetServiceInfoCommand : AbstractSchedulerCommand<GetServiceInfoOutput>
    {
        public GetServiceInfoCommand(IScheduler schedule) : base(schedule)
        {

        }

        protected override void ExecuteCore(FunctionSwitch input, GetServiceInfoOutput output)
        {
            if (input.Command == ECommand.GetServiceInfo)
            {
                var serviceInfo = new ServiceInfo();
                var serviceName = input.ServiceType.ServiceType;
                serviceInfo.EServiceStatus = GetStatus(serviceName);
                serviceInfo.Enable = serviceInfo.EServiceStatus != EServiceStatus.Pause;

                var trigger = Scheduler.GetTrigger(serviceName.GetTriggerKey());
                if (trigger != null)
                {
                    var cronBuilder = trigger as ICronTrigger;
                    serviceInfo.ScheduleInfo = JobCronExpressionConfig.GetCronExpression(serviceName + "Trigger");
                    var prev = trigger.GetPreviousFireTimeUtc();
                    if(prev.HasValue)
                    {
                        serviceInfo.PrevFiredTime = prev.Value.LocalDateTime;
                    }

                    var next = trigger.GetNextFireTimeUtc();
                    if(next.HasValue)
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
