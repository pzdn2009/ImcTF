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
                var serviceName = input.ServiceType.ServiceType;
                output.EServiceStatus = GetStatus(serviceName);
                output.Enable = output.EServiceStatus != EServiceStatus.Pause;

                var trigger = Scheduler.GetTrigger(serviceName.GetTriggerKey());
                if (trigger != null)
                {
                    var cronBuilder = trigger as ICronTrigger;
                    output.ScheduleInfo = JobCronExpressionConfig.GetCronExpression(serviceName + "Trigger");
                }
                else
                {
                    output.ScheduleInfo = string.Empty;
                }
            }
        }
    }
}
