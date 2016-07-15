using ImcFramework.Commands;
using ImcFramework.Data;
using ImcFramework.WcfInterface;
using Quartz;
using System;

namespace ImcFramework.Core.Quartz.Commands
{
    public abstract class AbstractSchedulerCommand : AbstractSchedulerCommand<ExecuteResult>
    {
        protected AbstractSchedulerCommand(IScheduler scheduler) : base(scheduler)
        {

        }
    }

    public abstract class AbstractSchedulerCommand<TOutput> : AbstractCommand<FunctionSwitch, TOutput> where TOutput : ExecuteResult, new()
    {
        protected IScheduler Scheduler { get; private set; }

        protected AbstractSchedulerCommand(IScheduler scheduler)
        {
            Scheduler = scheduler;
        }

        protected override void HandleError(Exception exception, FunctionSwitch input, TOutput output)
        {

        }

        public EServiceStatus GetStatus(string serviceName)
        {
            var state = Scheduler.GetTriggerState(serviceName.GetTriggerKey());
            if (state == TriggerState.Paused)
                return EServiceStatus.Pause;  //暂停

            foreach (var item in Scheduler.GetCurrentlyExecutingJobs())
            {
                if (item.JobDetail.Key.Name == serviceName)
                    return EServiceStatus.Running;  //运行
            }

            return EServiceStatus.Normal;
        }

        public JobDataMap ConvertToJobDataMap(RequestParameterList requestParameterList)
        {
            var jobDataMap = new JobDataMap();

            if (requestParameterList != null && requestParameterList.RequestParameters != null)
            {
                foreach (var item in requestParameterList.RequestParameters)
                {
                    jobDataMap.Add(item.Name, item.CommaValue);
                }
            }

            return jobDataMap;
        }
    }
}
