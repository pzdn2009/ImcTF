using ImcFramework.Data;
using ImcFramework.Infrastructure;
using Quartz;
using System.Linq;

namespace ImcFramework.Core.Quartz
{
    public class GlobalTriggerListener : ITriggerListener
    {
        public GlobalTriggerListener()
        {

        }

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

            //CommandInvoker.Invoke<ExecuteResult>(new WcfInterface.FunctionSwitch()
            //{
            //    Command = WcfInterface.ECommand.RunImmediately,
            //    ServiceType = EServiceTypeReader.ServiceTypes.FirstOrDefault(zw => zw.ServiceType == jobName)
            //});
        }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }
    }
}
