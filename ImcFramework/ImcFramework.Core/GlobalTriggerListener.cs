using ImcFramework.Infrastructure;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class GlobalTriggerListener : ITriggerListener
    {
        public string Name
        {
            get { return "GlobalTrigger"; }
        }

        public virtual void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {

        }

        public virtual void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {

        }

        public virtual void TriggerMisfired(ITrigger trigger)
        {
            var jobName = trigger.JobKey.Name;
            LogHelper.Error(string.Format("Job:{0} 错过了执行", jobName));
        }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }
    }
}
