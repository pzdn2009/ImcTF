using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;
using Quartz;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// Modify schedule command.
    /// </summary>
    public class ModifyScheduleCommand : AbstractSchedulerCommand
    {
        public ModifyScheduleCommand(IScheduler schedule) : base(schedule)
        {

        }

        /// <summary>
        /// Execute the <see cref="ECommand.ModifySchedule"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
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
