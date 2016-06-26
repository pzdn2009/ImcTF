using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using Quartz;

namespace ImcFramework.Core.Quartz.Commands
{
    public class ModifyScheduleCommand : AbstractSchedulerCommand
    {
        public ModifyScheduleCommand(IScheduler schedule) : base(schedule)
        {

        }

        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.ModifySchedule)
            {
                var serviceName = input.ServiceType.ServiceType;
                var cronExpresion = input.ScheduleFormat;

                var triggerKey = serviceName.GetTriggerKey();
                var triggerName = serviceName + "Trigger";
                var trigger = Scheduler.GetTrigger(triggerKey);
                if (trigger != null)
                {
                    var cronBuilder = trigger as ICronTrigger;
                    JobCronExpressionConfig.SetCronExpression(triggerName, cronExpresion);
                    cronBuilder.CronExpressionString = cronExpresion;
                    var newTrigger = cronBuilder.GetTriggerBuilder().Build();
                    Scheduler.PauseTrigger(triggerKey);
                    Scheduler.RescheduleJob(triggerKey, newTrigger);
                    Scheduler.ResumeTrigger(triggerKey);
                }
            }
        }
    }
}
