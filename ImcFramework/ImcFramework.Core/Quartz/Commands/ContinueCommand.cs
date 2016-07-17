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
    public class ContinueCommand : AbstractSchedulerCommand
    {
        public ContinueCommand(IScheduler schedule) : base(schedule)
        {
        }

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
