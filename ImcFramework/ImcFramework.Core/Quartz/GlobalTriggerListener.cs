using ImcFramework.LogPool;
using Quartz;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Global trigger listener.
    /// </summary>
    public class GlobalTriggerListener : ITriggerListener
    {
        private ILoggerPool loggerPool;

        public GlobalTriggerListener(ILoggerPool loggerPool)
        {
            this.loggerPool = loggerPool;
        }

        public virtual string Name
        {
            get { return "GlobalTrigger"; }
        }

        public virtual void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {

        }

        public virtual void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {
            loggerPool.Log(Name, new LogContentEntity()
            {
                Level = "Info",
                Message = string.Format("[{0}]:[{1}] fired", trigger.Key.Name, trigger.Key.Group)
            });
        }

        public virtual void TriggerMisfired(ITrigger trigger)
        {
            var jobName = trigger.JobKey.Name;

            loggerPool.Log(Name, new LogContentEntity()
            {
                Level = "Warn",
                Message = string.Format("[{0}]:[{1}]Misfired", trigger.Key.Name, trigger.Key.Group)
            });

            return;
        }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }
    }
}
