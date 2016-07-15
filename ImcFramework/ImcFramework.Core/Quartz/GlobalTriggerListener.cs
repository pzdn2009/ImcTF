using ImcFramework.Core.WcfService;
using ImcFramework.Data;
using ImcFramework.LogPool;
using Quartz;
using System.Linq;

namespace ImcFramework.Core.Quartz
{
    public class GlobalTriggerListener : ITriggerListener
    {
        private ILoggerPool loggerPool;
        private ICommandInvoker commandInvoker;
        private IServiceTypeReader serviceTypeReader;

        public GlobalTriggerListener(ILoggerPool loggerPool, ICommandInvoker commandInvoker, IServiceTypeReader serviceTypeReader)
        {
            this.loggerPool = loggerPool;
            this.commandInvoker = commandInvoker;
            this.serviceTypeReader = serviceTypeReader;
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

            commandInvoker.Invoke<ExecuteResult>(new WcfInterface.FunctionSwitch()
            {
                Command = WcfInterface.ECommand.RunImmediately,
                ServiceType = serviceTypeReader.GetEServiceTypes().FirstOrDefault(zw => zw.ServiceType == jobName)
            });
        }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }
    }
}
