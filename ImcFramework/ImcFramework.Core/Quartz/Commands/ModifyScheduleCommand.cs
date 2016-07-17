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
                var cronExpresion = input.ScheduleFormat;

                var trigger = Scheduler.GetTrigger(input.ServiceType);
                if (trigger != null)
                {
                    var cronBuilder = trigger as ICronTrigger;
                    JobCronExpressionConfig.SetCronExpression(trigger, cronExpresion);
                    cronBuilder.CronExpressionString = cronExpresion;
                    var newTrigger = cronBuilder.GetTriggerBuilder().Build();
                    Scheduler.PauseTrigger(trigger.Key);
                    Scheduler.RescheduleJob(trigger.Key, newTrigger);
                    Scheduler.ResumeTrigger(trigger.Key);
                }
            }
        }
    }
}
