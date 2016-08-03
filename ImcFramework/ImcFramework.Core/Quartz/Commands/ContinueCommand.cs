using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;
using Quartz;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// Continue command
    /// </summary>
    public class ContinueCommand : AbstractSchedulerCommand
    {
        public ContinueCommand(IScheduler schedule) : base(schedule)
        {
        }

        /// <summary>
        /// Execute the <see cref="ECommand.Continue"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.Continue)
            {
                if (Scheduler != null && Scheduler.IsStarted)
                {
                    Scheduler.ResumeTrigger(Scheduler.GetTrigger(input.ServiceType).Key);
                }
            }
        }
    }
}
