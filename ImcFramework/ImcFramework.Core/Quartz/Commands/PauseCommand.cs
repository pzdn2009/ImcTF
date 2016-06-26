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
    public class PauseCommand : AbstractSchedulerCommand
    {
        public PauseCommand(IScheduler schedule) : base(schedule)
        {
        }

        protected override void ExecuteCore(FunctionSwitch input, ExecuteResult output)
        {
            if (input.Command == ECommand.Pause)
            {
                var serviceName = input.ServiceType.ServiceType;

                Scheduler.PauseTrigger(serviceName.GetTriggerKey());
                bool yes = Scheduler.IsJobGroupPaused(serviceName + "Trigger");
            }
        }
    }
}
