using ImcFramework.Data;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;
using Quartz;

namespace ImcFramework.Core.Quartz.Commands
{
    /// <summary>
    /// Pause command.
    /// </summary>
    public class PauseCommand : AbstractSchedulerCommand
    {
        public PauseCommand(IScheduler schedule) : base(schedule)
        {
        }

        /// <summary>
        /// Execute the <see cref="ECommand.Pause"/> command.
        /// </summary>
        /// <param name="input">The input parameter.</param>
        /// <param name="output">The execute result.</param>
        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.Pause)
            {
                Scheduler.PauseTrigger(Scheduler.GetTrigger(input.ServiceType).Key);
            }
        }
    }
}
